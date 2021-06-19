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
        static void Main(string[] args)
        {
            Cart cart = new Cart();
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
                var command = Console.ReadLine();
                if(command.ToString().ToLower() == "add")
                {
                    Console.WriteLine("Enter a product SKU: ");
                    var stockKeepingUnit = Console.ReadLine();

                    var product = products.Find(x => x.StockKeepingUnit.ToUpper() == stockKeepingUnit.ToString().ToUpper());
                    if(product != null)
                    {
                        Console.WriteLine("Enter a Quantity: ");
                        var quantity = Math.Max(1, Convert.ToInt32(Console.ReadLine()));

                        CartEntry cartEntry = new CartEntry
                        {
                            Product = product,
                            Quantity = quantity
                        };

                        CartController.AddEntry(cart, cartEntry);
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
                    var cartIndex = Convert.ToInt32(Console.ReadLine()) - 1;

                    if(cartIndex >= 0 && cartIndex < cart.CartEntries.Count)
                    {
                        cart.CartEntries.RemoveAt(cartIndex);
                        Console.WriteLine("Product Removed!");
                    }
                    else
                    {
                        Console.WriteLine("Product Not Found!");
                    }

                }
                else if (command.ToString().ToLower() == "remove")
                {
                    Console.WriteLine("Goodbye!");
                    break;
                }

                Console.WriteLine("===================");
                int index = 1;
                var cartEntries = cart.CartEntries;
                foreach (CartEntry entry in cartEntries)
                {
                    Console.WriteLine($"{index}. {entry.Product.StockKeepingUnit}, Quantity: {entry.Quantity}, Cost: {CartEntryController.GetCost(entry)}");
                    index++;
                }
                Console.WriteLine($"Total Cost: {CartController.GetTotalCost(cart)}");
                Console.WriteLine("===================");
            }
        }
    }
}
