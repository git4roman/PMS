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
        Task Create(CategoryEntity entity);
        Task Update(CategoryEntity entity);
        Task Delete(CategoryEntity entity);
    }
}
