using Newtonsoft.Json;
using System;

namespace Emcredit.Empay.Models
{
    [Serializable]
    public class PurchaseUnitRequest
    {
        public AmountWithBreakdown Amount { get; set; }

        [JsonProperty(PropertyName = "custom_id")]
        public string CustomId { get; set; }

        public string Description { get; set; }

        [JsonProperty(PropertyName = "invoice_id")]
        public string InvoiceId { get; set; }

        //public List<Item> Items { get; set; }

        [JsonProperty(PropertyName = "reference_id")]
        public string ReferenceId { get; set; }

        //public ShippingDetails Shipping { get; set; }
        public string SoftDescriptor { get; set; }
    }
}