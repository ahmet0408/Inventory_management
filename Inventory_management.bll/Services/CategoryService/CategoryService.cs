using AutoMapper;
using Inventory_management.bll.DTOs.CategoryDTO;
using Inventory_management.dal.Data;
using Inventory_management.dal.Models.Category;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory_management.bll.Services.CategoryService
{
    public class CategoryService: ICategoryService
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;

        public CategoryService(ApplicationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task CreateCategory(CreateCategoryDTO modelDTO)
        {
            if (modelDTO != null)
            {
                Category category = _mapper.Map<Category>(modelDTO);
                category.ParentId=category.ParentId==0 ? null : category.ParentId;
                await _dbContext.Category.AddAsync(category);
                await _dbContext.SaveChangesAsync();
            }
        }

        public async Task EditCategory(EditCategoryDTO modelDTO)
        {
            if (modelDTO != null)
            {
                Category category = _mapper.Map<Category>(modelDTO);
                category.ParentId = category.ParentId == 0 ? null : category.ParentId;
                _dbContext.Category.Update(category);
                await _dbContext.SaveChangesAsync();
            }
        }

        public IEnumerable<CategoryDTO> GetCategories()
        {
            var categories = _dbContext.Category.Include(p => p.CategoryTranslates).ToList();
            var result = _mapper.Map<IEnumerable<CategoryDTO>>(categories);
            return result;
        }
    }
}
