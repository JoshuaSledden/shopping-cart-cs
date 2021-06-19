using System;
using Xunit;
using ShoppingCart.App.Models;
using ShoppingCart.App.Controllers;
using ShoppingCart.App.Constants;

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
        [InlineData(10, 1, (int)PromotionCodes.Types.NONE, 0, 0, 10)]
        [InlineData(15, 3, (int)PromotionCodes.Types.X_ITEMS_FOR_Y_COST, 3, 40, 40)]
        [InlineData(15, 4, (int)PromotionCodes.Types.X_ITEMS_FOR_Y_COST, 3, 40, 55)]
        [InlineData(15, 6, (int)PromotionCodes.Types.X_ITEMS_FOR_Y_COST, 3, 40, 80)]
        [InlineData(15, 8, (int)PromotionCodes.Types.X_ITEMS_FOR_Y_COST, 3, 40, 110)]
        [InlineData(55, 1, (int)PromotionCodes.Types.X_PERCENT_OFF_EVERY_Y_ITEMS, 2, 25, 55)]
        [InlineData(55, 2, (int)PromotionCodes.Types.X_PERCENT_OFF_EVERY_Y_ITEMS, 2, 25, 82.5)]
        [InlineData(55, 3, (int)PromotionCodes.Types.X_PERCENT_OFF_EVERY_Y_ITEMS, 2, 25, 137.5)]
        [InlineData(55, 4, (int)PromotionCodes.Types.X_PERCENT_OFF_EVERY_Y_ITEMS, 2, 25, 165)]
        [InlineData(55, 5, (int)PromotionCodes.Types.X_PERCENT_OFF_EVERY_Y_ITEMS, 2, 25, 220)]
        public void GetCostWithPromotion(int unitPrice, int quantity, int promotionCode, int appliedQuantity, int appliedValue, decimal expected)
        {
            /// <given />
            Promotion promotion = new Promotion
            {
                Code = promotionCode,
                AppliedQuantity = appliedQuantity,
                AppliedValue = appliedValue
            };

            CartEntry entry = new CartEntry
            {
                Product = new Product
                {
                    UnitPrice = unitPrice,
                    Promotion = promotion
                },
                Quantity = quantity
            };

            /// <when />

            /// <then />
            var result = CartEntryController.GetCost(entry);
            Assert.Equal(expected, result);
        }
    }
}
