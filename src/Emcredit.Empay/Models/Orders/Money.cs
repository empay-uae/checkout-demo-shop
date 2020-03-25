using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Emcredit.Empay.Models.Orders
{
    public class Money
    {
        [Required]
        public string CurrencyCode { get; set; }

        [Required]
        public string Value { get; set; }
    }
}