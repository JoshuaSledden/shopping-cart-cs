using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShoppingCart.App.Models;

namespace ShoppingCart.App.Utilities
{
    public static class PromotionCalculations
    {
        public static float GetFixedCostPromotionCost(CartEntry entry, Promotion promotion)
        {
            var promotionsApplied = (promotion.AppliedQuantity == 0) ? 0 : entry.Quantity / promotion.AppliedQuantity;
            var remainingQuantity = entry.Quantity % promotion.AppliedQuantity;
            return (promotion.AppliedValue * promotionsApplied) + (entry.Product.UnitPrice * remainingQuantity);
        }
        public static float GetPercentOffPromotionCost(CartEntry entry, Promotion promotion)
        {
            var promotionFactor = (1.0f - (promotion.AppliedValue * 0.01f));
            var promotionsApplied = (promotion.AppliedQuantity == 0) ? 0 : entry.Quantity / promotion.AppliedQuantity;
            var remainingQuantity = entry.Quantity % promotion.AppliedQuantity;

            var totalPromotionCost = 0.0f;
            for (int i = 0; i < promotionsApplied; i++)
            {
                totalPromotionCost += (entry.Product.UnitPrice * promotion.AppliedQuantity) * promotionFactor;
            }

            return totalPromotionCost + (entry.Product.UnitPrice * remainingQuantity);
        }
    }
}
