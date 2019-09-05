namespace Emcredit.Empay
{
    public class InitPaymentRequest
    {
        public InitPaymentRequest()
        {
            Header = new PaymentRequestHeader();
        }

        public int Amount { get; set; }
        public string BillerId { get; set; }
        public int CurrencyCode { get; set; }
        public PaymentRequestHeader Header { get; set; }
        public string OrderId { get; set; }
    }
}