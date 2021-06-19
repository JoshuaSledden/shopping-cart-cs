namespace ShoppingCart.App.Models
{
    /// <summary>
    /// An object model representing a shopping cart entry.
    /// </summary>
    public class CartEntry
    {
        /// <summary>
        /// Gets or sets a product object for the cart entry.
        /// </summary>
        public Product Product { get; set; }

        /// <summary>
        /// Gets or sets the quantity of products within this cart entry.
        /// </summary>
        public int Quantity { get; set; } = 1;
    }
}