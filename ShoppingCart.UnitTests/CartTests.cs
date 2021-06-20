using System;
using Xunit;
using ShoppingCart.App.Models;
using ShoppingCart.App.Controllers;
using System.Collections.Generic;

namespace ShoppingCart.UnitTests
{
    public class CartTests
    {
        [Fact]
        public void ShouldBeEmptyWhenFirstInitialized()
        {
            /// <given />
            ICartController cartController = new CartController(new Cart(), new CartEntryController());

            /// <when />

            /// <then />
            List<CartEntry> cartEntries = cartController.GetCartEntries();
            int resultCount = cartEntries.Count;
            decimal resultCost = cartController.GetTotalCost();
            Assert.Equal(0, resultCount);
            Assert.Equal(0.0M, resultCost);
        }

        [Fact]
        public void ShouldAddEntryToCart()
        {
            /// <given />
            ICartController cartController = new CartController(new Cart(), new CartEntryController());

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
            List<CartEntry> cartEntries = cartController.GetCartEntries();
            int result = cartEntries.Count;
            Assert.Equal(1, result);
        }

        [Fact]
        public void ShouldRemoveEntryFromCart()
        {
            /// <given />
            ICartController cartController = new CartController(new Cart(), new CartEntryController());

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
            List<CartEntry> cartEntries = cartController.GetCartEntries();
            int resultCount = cartEntries.Count;
            CartEntry resultEntry = cartEntries[0];
            Assert.Equal(1, resultCount);
            Assert.Equal("B", resultEntry.Product.StockKeepingUnit);
        }

        [Fact]
        public void ShouldRemoveEntryFromCartByIndex()
        {
            /// <given />
            ICartController cartController = new CartController(new Cart(), new CartEntryController());

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

            Product product3 = new Product
            {
                StockKeepingUnit = "C",
                UnitPrice = 25
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

            CartEntry entry3 = new CartEntry
            {
                Product = product3,
                Quantity = 1
            };

            cartController.AddEntry(entry1);
            cartController.AddEntry(entry2);
            cartController.AddEntry(entry3);

            /// <when />
            cartController.RemoveEntryByIndex(1);

            /// <then />
            List<CartEntry> cartEntries = cartController.GetCartEntries();
            int resultCount = cartEntries.Count;
            Assert.Equal(2, resultCount);
            Assert.Equal("A", cartEntries[0].Product.StockKeepingUnit);
            Assert.Equal("C", cartEntries[1].Product.StockKeepingUnit);
        }

        [Fact]
        public void ShouldGetTotalCostOfCart()
        {
            /// <given />
            ICartController cartController = new CartController(new Cart(), new CartEntryController());

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
