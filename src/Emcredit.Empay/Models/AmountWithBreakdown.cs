using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Emcredit.Empay.Models
{
    [Serializable]
    public class AmountWithBreakdown
    {
        //public AmountBreakdown Breakdown { get; set; }

        [JsonProperty(PropertyName = "currency_code")]
        public string CurrencyCode { get; set; }

        public string Value { get; set; }
    }
}