using ShoppingCart.App.Models;
using System.Collections.Generic;
using System.Linq;

namespace ShoppingCart.App.Controllers
{
    /// <summary>
    /// A static class for controlling cart operations.
    /// </summary>
    public class CartController : ICartController
    {
        private readonly Cart _cart;
        private readonly ICartEntryController _cartEntryController;

        /// <summary>
        /// Instantiates a cart controller class with a pre-existing cart input.
        /// </summary>
        /// <param name="cart"></param>
        public CartController(Cart cart, ICartEntryController cartEntryController)
        {
            _cart = cart;
            _cartEntryController = cartEntryController;
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
        /// Removes a cart entry in an existing cart.
        /// </summary>
        /// <param name="cart">An object representing a cart.</param>
        /// <param name="cartEntry">An object representing a cart entry.</param>
        public void RemoveEntry(CartEntry cartEntry)
        {
            _cart.CartEntries.Remove(cartEntry);
        }

        /// <summary>
        /// Removes a cart entry in an existing card via a provided index.
        /// </summary>
        /// <param name="index">The index in which we want to remove.</param>
        /// <returns>A bool representing the success state of removing an entry.</returns>
        public bool RemoveEntryByIndex(int index)
        {
            if (index >= 0 && index < _cart.CartEntries.Count)
            {
                _cart.CartEntries.RemoveAt(index);
                return true;
            }

            return false;
        }

        /// <summary>
        /// Gets the cart entries within this given cart.
        /// </summary>
        /// <returns>A list representing the entry objects within the cart.</returns>
        public List<CartEntry> GetCartEntries()
        {
            return _cart.CartEntries;
        }

        /// <summary>
        /// Gets the total cost value of all items within a cart.
        /// </summary>
        /// <param name="cart">An object representing a cart.</param>
        /// <returns>A decimal representing a total of all cart entries within the cart.</returns>
        public decimal GetTotalCost()
        {
            return _cart.CartEntries.Select(entry => _cartEntryController.GetCost(entry)).Sum();
        }
    }
}