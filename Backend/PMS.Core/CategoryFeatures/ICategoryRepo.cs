using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMS.Core.CategoryFeatures
{
    public interface ICategoryRepo
    {
        Task<IEnumerable<CategoryEntity>> GetAllCategories();
        Task<CategoryEntity> GetCategoryById(int id);
        Task Create(CategoryCreateDto dto);
        Task Update(CategoryUpdateDto dto);
        Task Delete(int id);
    }
}
