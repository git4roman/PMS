using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PMS.Core;
using PMS.Core.CategoryFeatures;
using PMS.DataAccess.Data;

namespace PMS.DataAccess.Repository
{
    public class CategoryRepo : ICategoryRepo
    {
        private AppDbContext _appDbContext;
        public CategoryRepo(AppDbContext appDbContext)
        {
            _appDbContext= appDbContext;
        }

        public Task Create(CategoryCreateDto dto)
        {
            throw new NotImplementedException();
        }

        public Task Delete(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<CategoryEntity>> GetAllCategories()
        {
           return await _appDbContext.Categories.ToListAsync();
        }

        public Task<CategoryEntity> GetCategoryById(int id)
        {
            throw new NotImplementedException();
        }

        public Task Update(CategoryUpdateDto dto)
        {
            throw new NotImplementedException();
        }
    }
}
