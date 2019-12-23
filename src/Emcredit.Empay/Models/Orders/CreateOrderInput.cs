using Emcredit.Empay.Models.Authorization;

namespace Emcredit.Empay.Models.Orders
{
    public class CreateOrderInput
    {
        public ApiEndpoint EmpayApiEndpoint { get; set; }
        public OrderRequest Request { get; set; }
    }
}