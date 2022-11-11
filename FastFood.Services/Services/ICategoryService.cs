using FastFood.Services.Models;
using FastFood.Services.Models.Categories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FastFood.Services.Services
{
    public interface ICategoryService
    {
        Task AddCategory(CreateCategoryDTO dto);

        Task<ICollection<ListCategoryDTO>> GetAll();
    }
}
