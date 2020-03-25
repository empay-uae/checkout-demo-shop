using Emcredit.Empay.Models.Orders;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace Emcredit.Empay.Models
{
    public class AmountWithBreakdown
    {
        public AmountBreakdown Breakdown { get; set; }

        [Required]
        public string CurrencyCode { get; set; }

        [Required]
        public string Value { get; set; }
    }
}