using System;
using System.Collections.Generic;
using System.Text;

namespace Emcredit.Empay.Models
{
    [Serializable]
    public class TransactionStatusHeader
    {
        public string ReasonCode { get; set; }
        public string ReasonDesc { get; set; }
        public bool Status { get; set; }
        public long TransactionId { get; set; }
    }
}