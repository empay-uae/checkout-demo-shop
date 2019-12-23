using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Emcredit.Empay.Models.Orders
{
    public class OrderRequest
    {
        public OrderRequest()
        {
            Intent = "CAPTURE";
            PurchaseUnits = new List<OrderRequestPurchaseUnit>();
        }

        [Required]
        public string Intent { get; set; }

        [Required]
        public OrderRequestPayee Payee { get; set; }

        public OrderRequestPayer Payer { get; set; }

        [Required]
        [JsonProperty(PropertyName = "purchase_units")]
        public ICollection<OrderRequestPurchaseUnit> PurchaseUnits { get; set; }
    }
}