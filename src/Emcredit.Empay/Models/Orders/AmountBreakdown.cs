using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Emcredit.Empay.Models.Orders
{
    public class AmountBreakdown
    {
        public Money Handling { get; set; }

        [Required]
        public Money ItemTotal { get; set; }

        public Money Shipping { get; set; }
        public Money ShippingDiscount { get; set; }
        public Money TaxTotal { get; set; }
    }
}