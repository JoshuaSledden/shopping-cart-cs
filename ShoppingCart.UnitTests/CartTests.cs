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

            CartEntry entry = new CartEntry
            {
                Product = product,
                Quantity = 1
            };

            /// <when />
            cart.AddItem(entry);

            /// <then />
            var result = cart.GetCount();
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

            cart.AddItem(entry1);
            cart.AddItem(entry2);

            /// <when />
            cart.RemoveItem(entry1);

            /// <then />
            var resultCount = cart.GetEntryCount();
            var resultEntry = cart.GetEntryByIndex();
            Assert.Equal(1, resultCount);
            Assert.Equal(resultEntry.Product.SKU, "B");
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
            cart.AddItem(entry1);
            cart.AddItem(entry2);

            /// <then />
            var resultCost = cart.GetTotalCost();
            Assert.Equal(40, resultCost);
        }
    }
}
