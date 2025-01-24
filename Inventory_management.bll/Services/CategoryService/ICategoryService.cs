using Inventory_management.bll.DTOs.CategoryDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory_management.bll.Services.CategoryService
{
    public interface ICategoryService
    {
        Task CreateCategory(CreateCategoryDTO modelDTO);
        Task EditCategory(EditCategoryDTO modelDTO);
        IEnumerable<CategoryDTO> GetCategories();
        Task RemoveCategory(int id);
    }
}
