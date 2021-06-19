using ShoppingCart.App.Models;

namespace ShoppingCart.App.Controllers
{
    /// <summary>
    /// A static class for controlling cart entry operations.
    /// </summary>
    public static class CartEntryController
    {
        public static float GetCost(CartEntry entry)
        {
            return 1.0f;
        }
    }
}