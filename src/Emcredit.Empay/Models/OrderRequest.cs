using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Emcredit.Empay.Models
{
    [Serializable]
    public class OrderRequest
    {
        public string Intent { get; set; }

        [JsonProperty(PropertyName = "purchase_units")]
        public List<PurchaseUnitRequest> PurchaseUnits { get; set; }
    }
}