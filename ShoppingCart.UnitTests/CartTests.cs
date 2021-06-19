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
            Cart cart = new Cart();

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
            CartController.AddEntry(cart, cartEntry);

            /// <then />
            var result = cart.CartEntries.Count;
            Assert.Equal(1, result);
        }

        [Fact]
        public void RemoveItem()
        {
            /// <given />
            Cart cart = new Cart();

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
                Quantity = 1
            };

            CartController.AddEntry(cart, entry1);
            CartController.AddEntry(cart, entry2);

            /// <when />
            CartController.RemoveEntry(cart, entry1);

            /// <then />
            var resultCount = cart.CartEntries.Count;
            var resultEntry = cart.CartEntries[0];
            Assert.Equal(1, resultCount);
            Assert.Equal("B", resultEntry.Product.StockKeepingUnit);
        }

        [Fact]
        public void GetTotalCost()
        {
            /// <given />
            Cart cart = new Cart();

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
            CartController.AddEntry(cart, entry1);
            CartController.AddEntry(cart, entry2);

            /// <then />
            var resultCost = CartController.GetTotalCost(cart);
            Assert.Equal(40.0f, resultCost);
        }
    }
}
