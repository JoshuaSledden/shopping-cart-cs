namespace ShoppingCart.App.Models
{
    /// <summary>
    /// An object model representing a product.
    /// </summary>
    public class Product
    {
        /// <summary>
        /// Gets or sets the Stock Keeping Unit (SKU).
        /// </summary>
        public string StockKeepingUnit { get; set; }

        /// <summary>
        /// Gets or sets the Unit Price.
        /// </summary>
        public int UnitPrice { get; set; }

        /// <summary>
        /// Gets or sets the Promotion object.
        /// </summary>
        public Promotion Promotion { get; set; }
    }
}