using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMS.Core.ProductFeatures
{
    public interface IProductRepo
    {
        Task<IEnumerable<ProductEntity>> GetAllProducts();
        Task<ProductEntity> GetProductById(int id);
        Task Create(ProductEntity entity);
        Task Update(ProductEntity entity);
        Task Delete(ProductEntity entity);
    }
}
