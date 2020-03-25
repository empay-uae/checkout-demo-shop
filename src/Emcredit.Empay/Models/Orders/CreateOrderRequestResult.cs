using System;
using System.Collections.Generic;

namespace Emcredit.Empay.Models.Orders
{
    [Serializable]
    public class CreateOrderRequestResult
    {
        public string Id { get; set; }
        public List<LinkDto> Links { get; set; }
        public string Status { get; set; }
    }
}