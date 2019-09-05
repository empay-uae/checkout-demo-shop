using Emcredit.Empay.Models;
using Emcredit.Empay.Services;
using Flurl.Http;
using System.Threading.Tasks;

namespace Emcredit.Empay
{
    public class OrdersService : IOrdersService
    {
        public async Task<Order> CreateOrderAsync(OrderRequest orderRequest)
        {
            return await $"{Constants.ApiBaseUrl}/api/v1/checkout/orders".PostJsonAsync(orderRequest).ReceiveJson<Order>();
        }
    }
}