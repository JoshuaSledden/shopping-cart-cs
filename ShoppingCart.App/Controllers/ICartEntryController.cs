using ShoppingCart.App.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCart.App.Controllers
{
    public interface ICartEntryController
    {
        /// <summary>
        /// Get the cost of an entry within a cart.
        /// </summary>
        /// <param name="entry">A card entry object that consists of a product (with or without a promotion) and a quantity of said product.</param>
        /// <returns>A decimal representing the complete cost of the products with the given quantity after any promotions.</returns>
        decimal GetCost(CartEntry entry);
    }
}
