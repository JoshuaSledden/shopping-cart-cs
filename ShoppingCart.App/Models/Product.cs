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
        public string StockKeepingUnit;

        /// <summary>
        /// Gets or sets the Unit Price.
        /// </summary>
        public int UnitPrice;

        /// <summary>
        /// Gets or sets the Promotion Code.
        /// </summary>
        public int PromotionCode;
    }
}