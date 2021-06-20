using ShoppingCart.App.Models;
using ShoppingCart.App.Constants;
using ShoppingCart.App.Utilities;

namespace ShoppingCart.App.Controllers
{
    /// <summary>
    /// A static class for controlling cart entry operations.
    /// </summary>
    public class CartEntryController : ICartEntryController
    {
        /// <summary>
        /// Get the cost of an entry within a cart.
        /// </summary>
        /// <param name="entry">A card entry object that consists of a product (with or without a promotion) and a quantity of said product.</param>
        /// <returns>A decimal representing the complete cost of the products with the given quantity after any promotions.</returns>
        public decimal GetCost(CartEntry entry)
        {
            var promotion = entry.Product.Promotion;

            if(promotion != null)
            {
                switch (promotion.Code)
                {
                    case (int)PromotionCodes.Types.X_ITEMS_FOR_Y_COST:
                        return PromotionCalculations.GetFixedCostPromotionCost(entry, promotion);
                    case (int)PromotionCodes.Types.X_PERCENT_OFF_EVERY_Y_ITEMS:
                        return PromotionCalculations.GetPercentOffPromotionCost(entry, promotion);
                    case (int)PromotionCodes.Types.NONE:
                    default:
                        break;
                }
            }

            return entry.Product.UnitPrice * entry.Quantity;
        }
    }
}