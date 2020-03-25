namespace Emcredit.Empay.Models.Orders
{
    public class CreateOrderInput
    {
        public EmpaySettings EmpaySettings { get; set; }
        public OrderRequest Request { get; set; }
    }
}