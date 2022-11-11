using AutoMapper;
using AutoMapper.QueryableExtensions;
using FastFood.Data;
using FastFood.Models;
using FastFood.Services.Models.Orders;
using FastFood.Services.Services;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FastFood.Services
{
    public class OrderService : IOrderService
    {
        private readonly IMapper mapper;
        private readonly FastFoodContext context;

        public OrderService(IMapper mapper, FastFoodContext context)
        {
            this.mapper = mapper;
            this.context = context;
        }
        public async Task AddOrder(CreateOrderDTO dto)
        {
            Order order = this.mapper.Map<Order>(dto);
            await this.context.AddAsync(order);
            await this.context.SaveChangesAsync();
           
        }

        public async Task<ICollection<ListOrderDTO>> GetAll()
        {

            ICollection<ListOrderDTO> list = await this.context
                .Orders
                .ProjectTo<ListOrderDTO>(this.mapper.ConfigurationProvider)
                .ToArrayAsync();
            return list;

        }
    }
}
