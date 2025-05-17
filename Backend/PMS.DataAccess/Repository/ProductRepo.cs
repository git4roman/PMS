using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PMS.Core.ProductFeatures;
using PMS.DataAccess.Data;

namespace PMS.DataAccess.Repository
{
    public class ProductRepo : IProductRepo
    {
        private readonly AppDbContext _appContext;
        public ProductRepo(AppDbContext appContext)
        {
            _appContext = appContext;
        }
        public async Task<IEnumerable<ProductEntity>> GetAllProducts()
        {
            return await _appContext.Products.ToListAsync();
        }
        public async Task<ProductEntity> GetProductById(int id)
        {
            return await _appContext.Products.FindAsync(id);
        }
        public async Task Create(ProductEntity entity)
        {
            await _appContext.Products.AddAsync(entity);
            await _appContext.SaveChangesAsync();
        }
        public async Task Update(ProductEntity entity)
        {
            _appContext.Products.Update(entity);
            await _appContext.SaveChangesAsync();
        }
        public async Task Delete(ProductEntity entity)
        {
            _appContext.Products.Remove(entity);
            await _appContext.SaveChangesAsync();
        }
    }
}
