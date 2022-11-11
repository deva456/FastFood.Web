using AutoMapper;
using AutoMapper.QueryableExtensions;

using FastFood.Data;
using FastFood.Models;
using FastFood.Services.Models.Items;
using FastFood.Services.Services;

using Microsoft.EntityFrameworkCore;

using System.Collections.Generic;
using System.Threading.Tasks;

namespace FastFood.Services
{
    public class ItemService : IItemService
    {
        private readonly FastFoodContext context;
        private readonly IMapper mapper;

        public ItemService(FastFoodContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }
        public async Task AddItem(CreateItemDTO dto)
        {
            Item item = this.mapper.Map<Item>(dto);
            await this.context.AddAsync(item);
            await this.context.SaveChangesAsync();
        }

        public async Task<bool> containsItem(string itemName)
        {
            return await this.context
                .Items
                .AnyAsync(x => x.Name == itemName);
        }

        public async Task<ICollection<ListItemDTO>> GetAll()
        {
            ICollection<ListItemDTO> itemDTOs = await this.context
                .Items
                .ProjectTo<ListItemDTO>(this.mapper.ConfigurationProvider)
                .ToArrayAsync();

            return itemDTOs;
        }

        public async Task<bool> validId(int id)
        {
            return await this.context
                 .Categories
                 .AnyAsync(x => x.Id == id);
        }


    }
}
