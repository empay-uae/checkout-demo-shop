using Emcredit.Empay.Models;
using System.Threading.Tasks;

namespace Emcredit.Empay.Services
{
    public interface IOrdersService
    {
        Task<Order> CreateOrderAsync(OrderRequest orderRequest);
    }
}