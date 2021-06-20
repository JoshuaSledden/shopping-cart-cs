using Newtonsoft.Json;
using ShoppingCart.App.Controllers;
using ShoppingCart.App.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;

namespace ShoppingCart.App
{
    class Program
    {
        /// <summary>
        /// Runs the application.
        /// Created a simple console navigation to interact with the code outside of unit testing.
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            ICartEntryController cartEntryController = new CartEntryController();
            ICartController cartController = new CartController(new Cart(), cartEntryController);
            List<Product> products = JsonConvert.DeserializeObject<List<Product>>(File.ReadAllText("Data/products.json"));
            Console.WriteLine("Shopping Cart");
            Console.WriteLine("===================");

            foreach(Product product in products)
            {
                Console.WriteLine($"Product SKU: {product.StockKeepingUnit}, Price: {product.UnitPrice}");
            }

            Console.WriteLine("===================");
            Console.WriteLine("Type 'Add' or 'Remove' to add or remove an item to your cart.");
            Console.WriteLine("Type 'Exit' to quit.");

            while (true)
            {
                string command = Console.ReadLine();
                if(command.ToString().ToLower() == "add")
                {
                    Console.WriteLine("Enter a product SKU: ");
                    string stockKeepingUnit = Console.ReadLine();

                    Product product = products.Find(x => x.StockKeepingUnit.ToUpper() == stockKeepingUnit.ToString().ToUpper());
                    if(product != null)
                    {
                        Console.WriteLine("Enter a Quantity: ");
                        int quantity = Math.Max(1, Convert.ToInt32(Console.ReadLine()));

                        CartEntry cartEntry = new CartEntry
                        {
                            Product = product,
                            Quantity = quantity
                        };

                        cartController.AddEntry(cartEntry);
                        Console.WriteLine("Product Added!");
                    }
                    else
                    {
                        Console.WriteLine("SKU not found!");
                    }
                }
                else if (command.ToString().ToLower() == "remove")
                {
                    Console.WriteLine("Select a number to remove: ");
                    int cartIndex = Convert.ToInt32(Console.ReadLine()) - 1;

                    bool result = cartController.RemoveEntryByIndex(cartIndex);
                    string resultString = result ? "Product Removed!" : "Product Not Found!";
                    Console.WriteLine(resultString);
                }
                else if (command.ToString().ToLower() == "remove")
                {
                    Console.WriteLine("Goodbye!");
                    break;
                }

                Console.WriteLine("===================");
                int index = 1;
                List<CartEntry> cartEntries = cartController.GetCartEntries();
                foreach (CartEntry entry in cartEntries)
                {
                    Console.WriteLine($"{index}. {entry.Product.StockKeepingUnit}, Quantity: {entry.Quantity}, Cost: {cartEntryController.GetCost(entry)}");
                    index++;
                }
                Console.WriteLine($"Total Cost: {cartController.GetTotalCost()}");
                Console.WriteLine("===================");
            }
        }
    }
}
