using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMS.Core.CategoryFeatures
{
    public class CategoryService
    {
        private readonly ICategoryRepo _categoryRepo;
        public CategoryService(ICategoryRepo categoryRepo)
        {
            _categoryRepo = categoryRepo;
        }
        public async Task<IEnumerable<CategoryEntity>> GetAllCategories()
        {
            return await _categoryRepo.GetAllCategories();
        }
        public async Task<CategoryEntity> GetCategoryById(int id)
        {
            return await _categoryRepo.GetCategoryById(id);
        }
        public async Task CreateCategory(CategoryCreateDto dto)
        {
            var entity = new CategoryEntity(dto.Name, dto.Description, dto.ImageUrl);
            await _categoryRepo.Create(entity);
        }
        public async Task UpdateCategory(int id,CategoryEntity category, CategoryUpdateDto dto)
        {
            category.Name = dto.Name;
            category.Description = dto.Description;
            category.ImageUrl = dto.ImageUrl;
            await _categoryRepo.Update(category);
        }
        public async Task DeleteCategory(CategoryEntity entity)
        {

            await _categoryRepo.Delete(entity);
        }
    }
}
