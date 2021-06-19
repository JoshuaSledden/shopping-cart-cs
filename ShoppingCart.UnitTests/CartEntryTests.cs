using System;
using Xunit;
using ShoppingCart.App.Models;
using ShoppingCart.App.Controllers;

namespace ShoppingCart.UnitTests
{
    public class CartEntryTests
    {
        [Fact]
        public void Quantity()
        {
            /// <given />
            CartEntry entry = new CartEntry
            {
                Product = new Product
                {
                    UnitPrice = 10
                },
                Quantity = 1
            };

            /// <when />
            entry.Quantity = 3;

            /// <then />
            var result = entry.Quantity;
            Assert.Equal(3, result);
        }

        [Theory]
        [InlineData(10, 1, 10)]
        [InlineData(10, 2, 20)]
        [InlineData(15, 3, 45)]
        [InlineData(100, 3, 300)]
        [InlineData(0, 5, 0)]
        public void GetCost(int unitPrice, int quantity, int expected)
        {
            /// <given />
            CartEntry entry = new CartEntry
            {
                Product = new Product
                {
                    UnitPrice = unitPrice
                },
                Quantity = quantity
            };

            /// <when />

            /// <then />
            var result = CartEntryController.GetCost(entry);
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(10, 1, 0, 10)]
        [InlineData(15, 3, 1, 40)]
        [InlineData(15, 4, 1, 55)]
        [InlineData(15, 6, 1, 80)]
        [InlineData(15, 8, 1, 110)]
        [InlineData(55, 1, 2, 55)]
        [InlineData(55, 2, 2, 82.5)]
        [InlineData(55, 3, 2, 137.5)]
        [InlineData(55, 4, 2, 165)]
        [InlineData(55, 5, 2, 220)]
        public void GetCostWithPromotion(int unitPrice, int quantity, int promotionCode, int expected)
        {
            /// <given />
            CartEntry entry = new CartEntry
            {
                Product = new Product
                {
                    UnitPrice = unitPrice
                },
                Quantity = quantity,
                PromotionCode = promotionCode
            };

            /// <when />

            /// <then />
            var result = CartEntryController.GetCost(entry);
            Assert.Equal(expected, result);
        }
    }
}
