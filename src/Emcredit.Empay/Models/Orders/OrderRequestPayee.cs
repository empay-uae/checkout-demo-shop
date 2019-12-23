using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations;

namespace Emcredit.Empay.Models.Orders
{
    [Serializable]
    public class OrderRequestPayee
    {
        [Required]
        //[MaxLength(Payee.BillerIdMaxLength)]
        [JsonProperty(PropertyName = "biller_id")]
        public string BillerId { get; set; }

        [JsonProperty(PropertyName = "display_name")]
        //[MaxLength(Payee.DisplayNameMaxLength)]
        public string DisplayName { get; set; }
    }
}