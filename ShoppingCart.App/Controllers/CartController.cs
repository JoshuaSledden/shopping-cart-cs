using ShoppingCart.App.Models;
using System.Linq;

namespace ShoppingCart.App.Controllers
{
    /// <summary>
    /// A static class for controlling cart operations.
    /// </summary>
    public class CartController : ICartController
    {
        private readonly Cart _cart;

        /// <summary>
        /// Instantiates a cart controller class with a pre-existing cart input.
        /// </summary>
        /// <param name="cart"></param>
        public CartController(Cart cart)
        {
            _cart = cart;
        }

        /// <summary>
        /// Adds a cart entry in to an existing cart.
        /// </summary>
        /// <param name="cart">An object representing a cart.</param>
        /// <param name="cartEntry">An object representing a cart entry.</param>
        public void AddEntry(CartEntry cartEntry)
        {
            _cart.CartEntries.Add(cartEntry);
        }

        /// <summary>
        /// Removes a cart entry in to an existing cart.
        /// </summary>
        /// <param name="cart">An object representing a cart.</param>
        /// <param name="cartEntry">An object representing a cart entry.</param>
        public void RemoveEntry(CartEntry cartEntry)
        {
            _cart.CartEntries.Remove(cartEntry);
        }

        /// <summary>
        /// Gets the total cost value of all items within a cart.
        /// </summary>
        /// <param name="cart">An object representing a cart.</param>
        /// <returns>A decimal representing a total of all cart entries within the cart.</returns>
        public decimal GetTotalCost()
        {
            return _cart.CartEntries.Select(entry => CartEntryController.GetCost(entry)).Sum();
        }
    }
}