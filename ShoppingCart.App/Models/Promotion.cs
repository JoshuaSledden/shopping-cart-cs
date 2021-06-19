using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCart.App.Models
{
    /// <summary>
    /// A class model used to define types of promotions.
    /// </summary>
    public class Promotion
    {
        /// <summary>
        /// Gets or sets the promotional code.
        /// </summary>
        public int Code { get; set; }

        /// <summary>
        /// Gets or sets the item quantity in which the promotion is applied to.
        /// </summary>
        public int AppliedQuantity { get; set; }

        /// <summary>
        /// Gets or sets the promotional value.
        /// </summary>
        public float AppliedValue { get; set; }
    }
}
