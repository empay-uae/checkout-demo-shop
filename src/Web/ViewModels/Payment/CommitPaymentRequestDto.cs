using Emcredit.Empay;

namespace Microsoft.eShopWeb.Web.ViewModels.Payment
{
    public partial class CommitPaymentRequestDto
    {
        public PaymentRequestHeader Header { get; set; }
        public string TxnToken { get; set; }
    }
}