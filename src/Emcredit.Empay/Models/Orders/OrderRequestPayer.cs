using Newtonsoft.Json;
using System;

namespace Emcredit.Empay.Models.Orders
{
    // TODO(abhith): get models from single place for demo as well as core

    [Serializable]
    public class OrderRequestPayer
    {
        //[MaxLength(Payer.EmailMaxLength)]
        [JsonProperty(PropertyName = "email_address")]
        public string Email { get; set; }

        //[MaxLength(Payer.MobileMaxLength)]
        [JsonProperty(PropertyName = "mobile_number")]
        public string Mobile { get; set; }

        public OrderRequestPayerName Name { get; set; }
    }
}