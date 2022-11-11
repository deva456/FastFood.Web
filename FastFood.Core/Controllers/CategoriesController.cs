namespace FastFood.Core.Controllers
{
    using AutoMapper;
    using Microsoft.AspNetCore.Mvc;

    using FastFood.Services.Models;
    using FastFood.Services.Models.Categories;
    using FastFood.Services.Services;
    using ViewModels.Categories;

    using System.Collections.Generic;
    using System.Threading.Tasks;
    

    public class CategoriesController : Controller
    {
        private readonly ICategoryService categoryService;
        private readonly IMapper mapper;

        public CategoriesController(ICategoryService categoryService, IMapper mapper)
        {
            this.categoryService = categoryService;
            this.mapper = mapper;
        }

        public IActionResult Create()
        {
            return this.View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateCategoryInputModel model)
        {
            if (ModelState.IsValid == false)
            {
                return RedirectToAction("Create","Categories");
            }

            CreateCategoryDTO categoryDTO = this.mapper.Map<CreateCategoryDTO>(model);
            await this.categoryService.AddCategory(categoryDTO);
            return RedirectToAction("All", "Categories");
        }

        public async Task<IActionResult> All()
        {
            ICollection<ListCategoryDTO> categoryDTOs = await this.categoryService.GetAll();
            IList<CategoryAllViewModel> categoryAll = new List<CategoryAllViewModel>();
            foreach (ListCategoryDTO dTO in categoryDTOs)
            {
                categoryAll.Add(this.mapper.Map<CategoryAllViewModel>(dTO));
            }
            return this.View(categoryAll);
        }
    }
}
