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
            Channel = "WEB_CHECKOUT";
            PurchaseUnits = new List<OrderRequestPurchaseUnit>();
        }

        [Required]
        public string Channel { get; set; }

        [Required]
        public string Intent { get; set; }

        [Required]
        public ICollection<OrderRequestPurchaseUnit> PurchaseUnits { get; set; }
    }
}