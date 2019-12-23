using Newtonsoft.Json;

namespace Emcredit.Empay.Models.Orders
{
    public class OrderRequestPayerName
    {
        [JsonProperty(PropertyName = "given_name")]
        public string GivenName { get; set; }

        public string Surname { get; set; }
    }
}