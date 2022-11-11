namespace FastFood.Core.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using AutoMapper;
    using Data;
    using FastFood.Services.Models.Orders;
    using FastFood.Services.Services;
    using Microsoft.AspNetCore.Mvc;
    using ViewModels.Orders;

    public class OrdersController : Controller
    {
        private readonly FastFoodContext context;
        private readonly IMapper mapper;
        private readonly IOrderService service;
        public OrdersController(FastFoodContext context, IMapper mapper, IOrderService service)
        {
            this.context = context;
            this.mapper = mapper;
            this.service = service;
        }

        public IActionResult Create()
        {
            var viewOrder = new CreateOrderViewModel
            {
                Items = this.context.Items.Select(x => x.Id).ToList(),
                Employees = this.context.Employees.Select(x => x.Id).ToList(),
            };

            return this.View(viewOrder);
        }

        [HttpPost]
        public IActionResult Create(CreateOrderInputModel model)
        { 
            return this.RedirectToAction("All", "Orders");
        }

        public async Task<IActionResult> All()
        {
            ICollection<ListOrderDTO> orderDTOs = await this.service.GetAll();
            IList<OrderAllViewModel> all = new List<OrderAllViewModel>();
            foreach (var dto in orderDTOs)
            {
                all.Add(this.mapper.Map<OrderAllViewModel>(dto));
            }
           return this.View(all);
        }
    }
}
