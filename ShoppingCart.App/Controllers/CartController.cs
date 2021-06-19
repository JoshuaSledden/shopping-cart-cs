using ShoppingCart.App.Models;

namespace ShoppingCart.App.Controllers
{
    /// <summary>
    /// A static class for controlling cart operations.
    /// </summary>
    public static class CartController
    {
        /// <summary>
        /// Adds a cart entry in to an existing cart.
        /// </summary>
        /// <param name="cart">An object representing a cart.</param>
        /// <param name="cartEntry">An object representing a cart entry.</param>
        public static void AddEntry(Cart cart, CartEntry cartEntry)
        {
            cart.CartEntries.Add(cartEntry);
        }

        /// <summary>
        /// Removes a cart entry in to an existing cart.
        /// </summary>
        /// <param name="cart">An object representing a cart.</param>
        /// <param name="cartEntry">An object representing a cart entry.</param>
        public static void RemoveEntry(Cart cart, CartEntry cartEntry)
        {
            cart.CartEntries.Remove(cartEntry);
        }

        /// <summary>
        /// Gets the total cost value of all items within a cart.
        /// </summary>
        /// <param name="cart">An object representing a cart.</param>
        /// <returns></returns>
        public static float GetTotalCost(Cart cart)
        {
            return 1.0f;
        }
    }
}