using ShoppingCart.App.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCart.App.Controllers
{
    /// <summary>
    /// An interface representing a cart controller.
    /// </summary>
    public interface ICartController
    {
        /// <summary>
        /// Adds a cart entry in to an existing cart.
        /// </summary>
        /// <param name="cart">An object representing a cart.</param>
        /// <param name="cartEntry">An object representing a cart entry.</param>
        void AddEntry(CartEntry cartEntry);

        /// <summary>
        /// Removes a cart entry in to an existing cart.
        /// </summary>
        /// <param name="cart">An object representing a cart.</param>
        /// <param name="cartEntry">An object representing a cart entry.</param>
        void RemoveEntry(CartEntry cartEntry);

        /// <summary>
        /// Removes a cart entry in an existing card via a provided index.
        /// </summary>
        /// <param name="index">The index in which we want to remove.</param>
        /// <returns>A bool representing the success state of removing an entry.</returns>
        bool RemoveEntryByIndex(int index);

        /// <summary>
        /// Gets the cart entries within this given cart.
        /// </summary>
        /// <returns>A list representing the entry objects within the cart.</returns>
        List<CartEntry> GetCartEntries();

        /// <summary>
        /// Gets the total cost value of all items within a cart.
        /// </summary>
        /// <param name="cart">An object representing a cart.</param>
        /// <returns>A decimal representing a total of all cart entries within the cart.</returns>
        decimal GetTotalCost();
    }
}
