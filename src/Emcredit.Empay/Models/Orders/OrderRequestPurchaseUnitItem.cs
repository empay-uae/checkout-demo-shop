using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Emcredit.Empay.Models.Orders
{
    public class OrderRequestPurchaseUnitItem
    {
        public Dictionary<string, string> Attributes { get; set; }

        [MaxLength(127)]
        public string Description { get; set; }

        [Required]
        [MaxLength(127)]
        public string Name { get; set; }

        [Required]
        [Range(1, int.MaxValue)]
        public int Quantity { get; set; }

        public Money Tax { get; set; }

        [Required]
        public Money UnitAmount { get; set; }
    }
}