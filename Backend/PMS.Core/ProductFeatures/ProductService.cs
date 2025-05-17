using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PMS.Core.CategoryFeatures;

namespace PMS.Core.ProductFeatures
{
    public class ProductService
    {
        private readonly IProductRepo _productRepo;
        public ProductService(IProductRepo productRepo)
        {
            _productRepo = productRepo;
        }
        public async Task<IEnumerable<ProductEntity>> GetAllProducts()
        {
            return await _productRepo.GetAllProducts();
        }
        public async Task<ProductEntity> GetProductById(int id)
        {
            return await _productRepo.GetProductById(id);
        }
        public async Task CreateProduct(ProductCreateDto dto)
        {
            var entity = new ProductEntity(dto.Name, dto.Description, dto.ImageUrl, dto.CategoryId, dto.Quantity, dto.Price);
            await _productRepo.Create(entity);


        }
        public async Task UpdateProduct(int id, ProductEntity product, ProductUpdateDto dto)
        {
            product.Name = dto.Name;
            product.Description = dto.Description;
            product.ImageUrl = dto.ImageUrl;
            product.CategoryId = dto.CategoryId;
            product.Quantity = dto.Quantity;
            product.Price = dto.Price;
            product.UpdateTimestamp();
            await _productRepo.Update(product);
        }
        public async Task DeleteProduct(ProductEntity entity)
        {
            await _productRepo.Delete(entity);
        }
    }
}
