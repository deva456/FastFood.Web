using FastFood.Services.Models.Items;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FastFood.Services.Services
{
    public interface IItemService
    {
        Task AddItem(CreateItemDTO dto);

        Task<ICollection<ListItemDTO>> GetAll();

        Task<bool> validId(int id);

        Task<bool> containsItem(string itemName);
    }
}
