using Emcredit.Empay.Models;
using System;

namespace Emcredit.Empay
{
    [Serializable]
    public class CommitPaymentResult
    {
        public string ApprovalCode { get; set; }
        public TransactionStatusHeader Header { get; set; }
        public string OrderId { get; set; }
    }
}