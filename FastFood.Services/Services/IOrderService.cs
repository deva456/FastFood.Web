using FastFood.Services.Models.Orders;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FastFood.Services.Services
{
    public interface IOrderService
    {
        Task AddOrder(CreateOrderDTO dto);
        Task<ICollection<ListOrderDTO>> GetAll();
    }
}
