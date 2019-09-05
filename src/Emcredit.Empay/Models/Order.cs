using System;
using System.Collections.Generic;
using System.Text;

namespace Emcredit.Empay.Models
{
    [Serializable]
    public class Order
    {
        public string Id { get; set; }
        public List<LinkDto> Links { get; set; }
        public string Status { get; set; }
    }
}