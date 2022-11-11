namespace FastFood.Core.Controllers
{
    using AutoMapper;
    using FastFood.Services.Models.Categories;
    using FastFood.Services.Models.Items;
    using FastFood.Services.Services;
    using Microsoft.AspNetCore.Mvc;

   
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using ViewModels.Items;

    public class ItemsController : Controller
    {
        private readonly ICategoryService category;
        private readonly IMapper mapper;
        private readonly IItemService service;

        public ItemsController(ICategoryService category, IMapper mapper, IItemService service)
        {
            this.mapper = mapper;
            this.category = category;
            this.service = service;
           
        }

       
        public async Task<IActionResult> Create()
        {
                ICollection<ListCategoryDTO> categories = await this.category
                .GetAll();
            IList<CreateItemViewModel> itemViewModels = new List<CreateItemViewModel>();

            foreach (ListCategoryDTO dto in categories)
            {
                itemViewModels.Add(this.mapper.Map<CreateItemViewModel>(dto));
            }

            return this.View(itemViewModels);
        }

        [HttpPost]

        
        public async Task<IActionResult> Create(CreateItemInputModel model)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Create", "Items");
            }
            bool validCategory = await service.validId(model.CategoryId);
            if (!validCategory)
            {
                return RedirectToAction("Create", "Items");
            }
            bool alreadyHasItem = await service.containsItem(model.Name);
            if (alreadyHasItem)
            {
                return RedirectToAction("Create", "Items");
            }

            CreateItemDTO itemDTO = this.mapper.Map<CreateItemDTO>(model);
            await this.service.AddItem(itemDTO);

           
            return this.RedirectToAction("All", "Items");
        }

        public async Task<IActionResult> All()  
        {
            ICollection<ListItemDTO> itemDTOs = await this.service.GetAll();
            IList<ItemsAllViewModels> itemsAlls = new List<ItemsAllViewModels>();
            foreach (var dto in itemDTOs)
            {
                itemsAlls.Add(this.mapper.Map<ItemsAllViewModels>(dto));
            }
            return this.View(itemsAlls);
        }
    }
}
