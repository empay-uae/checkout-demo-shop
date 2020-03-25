namespace Emcredit.Empay.Models
{
    public class EmpaySettings
    {
        public string ApiEndpointUrl { get; set; }
        public string BillerId { get; set; }
        public string ClientId { get; set; }
        public string ClientSecret { get; set; }
        public string Scope { get; set; }
        public string TokenEndpointUrl { get; set; }
    }
}