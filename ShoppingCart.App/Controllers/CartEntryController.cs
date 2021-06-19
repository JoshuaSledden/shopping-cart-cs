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
            switch(entry.PromotionCode)
            {
                case (int)Promotion.Codes.X_FOR_Y:
                    return 1.0f;
                case (int)Promotion.Codes.X_PERCENT_OFF_EVERY_Y:
                    return 1.0f;
                case (int)Promotion.Codes.NONE:
                default:
                    return entry.Product.UnitPrice * entry.Quantity;
            }
        }
    }
}