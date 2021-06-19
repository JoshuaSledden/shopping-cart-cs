using ShoppingCart.App.Models;
using ShoppingCart.App.Constants;

namespace ShoppingCart.App.Controllers
{
    /// <summary>
    /// A static class for controlling cart entry operations.
    /// </summary>
    public static class CartEntryController
    {
        public static float GetCost(CartEntry entry)
        {
            var promotion = entry.Product.Promotion;

            if(promotion != null)
            {
                switch (promotion.Code)
                {
                    case (int)PromotionCodes.Types.X_ITEMS_FOR_Y_COST:
                        {
                            var promotionAmounts = (promotion.AppliedQuantity == 0) ? 0 : entry.Quantity / promotion.AppliedQuantity;
                            var remainingQuantity = entry.Quantity % promotion.AppliedQuantity;
                            return (promotion.AppliedValue * promotionAmounts) + (entry.Product.UnitPrice * remainingQuantity);
                        }
                    case (int)PromotionCodes.Types.X_PERCENT_OFF_EVERY_Y_ITEMS:
                        return 1.0f;
                    case (int)PromotionCodes.Types.NONE:
                    default:
                        break;
                }
            }

            return entry.Product.UnitPrice * entry.Quantity;
        }
    }
}