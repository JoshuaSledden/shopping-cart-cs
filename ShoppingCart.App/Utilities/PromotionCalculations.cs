using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShoppingCart.App.Models;

namespace ShoppingCart.App.Utilities
{
    /// <summary>
    /// A static class that holds promotion calculation operations.
    /// </summary>
    public static class PromotionCalculations
    {
        /// <summary>
        /// Gets the total cost of a series of products within a cart entry based on the X items for Y Cost promotion.
        /// </summary>
        /// <param name="entry">An object representing a card entry.</param>
        /// <param name="promotion">An object representing a promotion type object.</param>
        /// <returns>A decimal value representing the overall cost of this cart entry after promotion.</returns>
        public static decimal GetFixedCostPromotionCost(CartEntry entry, Promotion promotion)
        {
            var promotionsApplied = (promotion.AppliedQuantity == 0) ? 0 : entry.Quantity / promotion.AppliedQuantity;
            var remainingQuantity = entry.Quantity % promotion.AppliedQuantity;
            return (promotion.AppliedValue * promotionsApplied) + (entry.Product.UnitPrice * remainingQuantity);
        }

        /// <summary>
        /// Gets the total cost of a series of products within a cart entry based on the X Percent off for every Y Items promotion.
        /// </summary>
        /// <param name="entry">An object representing a card entry.</param>
        /// <param name="promotion">An object representing a promotion type object.</param>
        /// <returns>A decimal value representing the overall cost of this cart entry after promotion.</returns>
        public static decimal GetPercentOffPromotionCost(CartEntry entry, Promotion promotion)
        {
            var promotionFactor = (1.0M - (promotion.AppliedValue * 0.01M));
            var promotionsApplied = (promotion.AppliedQuantity == 0) ? 0 : entry.Quantity / promotion.AppliedQuantity;
            var remainingQuantity = entry.Quantity % promotion.AppliedQuantity;

            var totalPromotionCost = 0.0M;
            for (int i = 0; i < promotionsApplied; i++)
            {
                totalPromotionCost += (entry.Product.UnitPrice * promotion.AppliedQuantity) * promotionFactor;
            }

            return totalPromotionCost + (entry.Product.UnitPrice * remainingQuantity);
        }
    }
}
