using Emcredit.Empay.Models;
using System;

namespace Emcredit.Empay
{
    [Serializable]
    public class InitPaymentResult
    {
        public TransactionStatusHeader Header { get; set; }

        public string MerchantCode { get; set; }
        public string OrderId { get; set; }
        public PaymentServiceFee ServiceFee { get; set; }
        public string Token { get; set; }
    }

    [Serializable]
    public class PaymentServiceFee
    {
        public int BaseFee { get; set; }
        public int CommissionRate { get; set; }
        public int NetAmount { get; set; }
    }
}