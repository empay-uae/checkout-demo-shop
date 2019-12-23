using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Emcredit.Empay.Models.Orders
{
    public class OrderRequestPurchaseUnit
    {
        public AmountWithBreakdown Amount { get; set; }

        [MaxLength(127)]
        [JsonProperty(PropertyName = "custom_id")]
        public string CustomId { get; set; }

        [MaxLength(127)]
        public string Description { get; set; }

        [MaxLength(127)]
        [JsonProperty(PropertyName = "invoice_id")]
        public string InvoiceId { get; set; }

        //TODO
        //public List<Item> Items { get; set; }

        [MaxLength(250)]
        [JsonProperty(PropertyName = "reference_id")]
        public string ReferenceId { get; set; }

        //TODO
        //public ShippingDetails Shipping { get; set; }
    }
}