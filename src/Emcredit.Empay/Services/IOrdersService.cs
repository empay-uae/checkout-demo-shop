using Emcredit.Empay.Models;
using Emcredit.Empay.Models.Orders;
using System.Threading.Tasks;

namespace Emcredit.Empay.Services
{
    public interface IOrdersService
    {
        Task<Order> CreateOrderAsync(CreateOrderInput input);
    }
}