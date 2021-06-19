using ShoppingCart.App.Models;

namespace ShoppingCart.App.Controllers
{
    /// <summary>
    /// A static class for controlling cart operations.
    /// </summary>
    public static class CartController
    {
        public static void AddEntry(Cart cart, CartEntry cartEntry)
        {
            cart.CartEntries.Add(cartEntry);
        }

        public static void RemoveEntry(Cart cart, CartEntry cartEntry)
        {
            cart.CartEntries.Remove(cartEntry);
        }

        public static float GetTotalCost(Cart cart)
        {
            return 1.0f;
        }
    }
}