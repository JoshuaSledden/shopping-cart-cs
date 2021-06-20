using System;
using Xunit;
using ShoppingCart.App.Models;
using ShoppingCart.App.Controllers;

namespace ShoppingCart.UnitTests
{
    public class CartTests
    {
        [Fact]
        public void AddItem()
        {
            /// <given />
            ICartController cartController = new CartController(new Cart());

            Product product = new Product
            {
                UnitPrice = 10
            };

            CartEntry cartEntry = new CartEntry
            {
                Product = product,
                Quantity = 1
            };

            /// <when />
            cartController.AddEntry(cartEntry);

            /// <then />
            int result = cart.CartEntries.Count;
            Assert.Equal(1, result);
        }

        [Fact]
        public void RemoveItem()
        {
            /// <given />
            Cart cart = new Cart();
            ICartController cartController = new CartController(cart);

            Product product1 = new Product
            {
                StockKeepingUnit = "A",
                UnitPrice = 10
            };

            Product product2 = new Product
            {
                StockKeepingUnit = "B",
                UnitPrice = 15
            };

            CartEntry entry1 = new CartEntry
            {
                Product = product1,
                Quantity = 1
            };

            CartEntry entry2 = new CartEntry
            {
                Product = product2,
                Quantity = 1
            };

            cartController.AddEntry(entry1);
            cartController.AddEntry(entry2);

            /// <when />
            cartController.RemoveEntry(entry1);

            /// <then />
            int resultCount = cart.CartEntries.Count;
            CartEntry resultEntry = cart.CartEntries[0];
            Assert.Equal(1, resultCount);
            Assert.Equal("B", resultEntry.Product.StockKeepingUnit);
        }

        [Fact]
        public void GetTotalCost()
        {
            /// <given />
            ICartController cartController = new CartController(new Cart());

            Product product1 = new Product
            {
                UnitPrice = 10
            };

            Product product2 = new Product
            {
                UnitPrice = 15
            };

            CartEntry entry1 = new CartEntry
            {
                Product = product1,
                Quantity = 1
            };

            CartEntry entry2 = new CartEntry
            {
                Product = product2,
                Quantity = 2
            };

            /// <when />
            cartController.AddEntry(entry1);
            cartController.AddEntry(entry2);

            /// <then />
            decimal resultCost = cartController.GetTotalCost();
            Assert.Equal(40.0M, resultCost);
        }
    }
}
