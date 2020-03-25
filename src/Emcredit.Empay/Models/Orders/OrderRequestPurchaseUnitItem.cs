using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Emcredit.Empay.Models.Orders
{
    public class OrderRequestPurchaseUnitItem
    {
        public string Category { get; set; }

        [MaxLength(127)]
        public string Description { get; set; }

        [Required]
        [MaxLength(127)]
        public string Name { get; set; }

        [Required]
        [Range(1, double.MaxValue)]
        public int Quantity { get; set; }

        [MaxLength(127)]
        public string Sku { get; set; }

        public Money Tax { get; set; }

        [Required]
        public Money UnitAmount { get; set; }
    }
}