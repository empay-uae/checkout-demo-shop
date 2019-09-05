namespace Emcredit.Empay
{
    public class PaymentRequestHeader
    {
        public string CustomerId { get; set; }
        public int CustomerIdType { get; set; }
        public string SessionId { get; set; }
    }
}