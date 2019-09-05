namespace Emcredit.Empay
{
    public class CommitPaymentRequest
    {
        public CommitPaymentRequest()
        {
            DeviceInfo = new DeviceInfo();
            Header = new PaymentRequestHeader();
        }

        public int Amount { get; set; }
        public string BillerId { get; set; }
        public string BillId { get; set; }
        public int CurrencyCode { get; set; }
        public DeviceInfo DeviceInfo { get; set; }
        public PaymentRequestHeader Header { get; set; }
        public string OrderId { get; set; }
        public string TransactionToken { get; set; }
    }
}