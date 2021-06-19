namespace ShoppingCart.App.Constants
{
    /// <summary>
    /// A static class to hold constant promotional value type ids.
    /// </summary>
    public static class PromotionCodes
    {
        /// <summary>
        /// An enumeration of promotional type ids.
        /// </summary>
        public enum Types : int
        {
            NONE = 0,
            X_ITEMS_FOR_Y_COST,
            X_PERCENT_OFF_EVERY_Y_ITEMS
        }
    }
}