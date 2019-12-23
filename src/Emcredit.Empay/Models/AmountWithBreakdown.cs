using Newtonsoft.Json;

namespace Emcredit.Empay.Models
{
    public class AmountWithBreakdown
    {
        //public AmountBreakdown Breakdown { get; set; }

        [JsonProperty(PropertyName = "currency_code")]
        public string CurrencyCode { get; set; }

        public string Value { get; set; }
    }
}