using System.Collections.Generic;

namespace ShoppingCart.App.Models
{
    /// <summary>
    /// An object model representing a shopping cart that holds all cart entries.
    /// </summary>
    public class Cart
    {
        /// <summary>
        /// Gets or sets a collection of cart entry objects.
        /// </summary>
        public List<CartEntry> CartEntries = new List<CartEntry>();
    }
}