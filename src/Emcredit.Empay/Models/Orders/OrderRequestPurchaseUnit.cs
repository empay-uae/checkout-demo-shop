using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Emcredit.Empay.Models.Orders
{
    public class OrderRequestPurchaseUnit
    {
        public OrderRequestPurchaseUnit()
        {
            Items = new List<OrderRequestPurchaseUnitItem>();
        }

        public AmountWithBreakdown Amount { get; set; }
        public Dictionary<string, string> Attributes { get; set; }

        [MaxLength(127)]
        public string CustomId { get; set; }

        [MaxLength(127)]
        public string Description { get; set; }

        [MaxLength(127)]
        public string InvoiceId { get; set; }

        public ICollection<OrderRequestPurchaseUnitItem> Items { get; set; }

        [Required]
        public OrderRequestPurchaseUnitPayee Payee { get; set; }

        [MaxLength(250)]
        public string ReferenceId { get; set; }
    }
}