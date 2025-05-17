using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PMS.Core.ProductFeatures;
using PMS.Core.Utility;
using PMS.Web.Models.Products;

namespace PMS.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly ProductService _productService;
        private readonly CloudinaryService _cloudinaryService;
        private readonly ILogger<ProductController> _logger;

        public ProductController(ProductService productService, CloudinaryService cloudinaryService, ILogger<ProductController> logger)
        {
            _productService = productService;
            _cloudinaryService = cloudinaryService;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> GetProducts()
        {
            var list = await _productService.GetAllProducts();
            return Ok(list);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProduct(int id)
        {
            var product = await _productService.GetProductById(id);
            return Ok(product);
        }
        [HttpPost]
        [Consumes("multipart/form-data")]
        public async Task<IActionResult> CreateProduct([FromForm] ProductCreateViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (vm.Image == null || vm.Image.Length == 0)
            {
                return BadRequest("Image is required");
            }
            var dto = new ProductCreateDto
            {
                Name = vm.Name,
                Description = vm.Description,
                CategoryId = vm.CategoryId,
                Quantity = vm.Quantity,
                Price = vm.Price
            };      

            try
            {
                dto.ImageUrl = await _cloudinaryService.UploadImageAsync(vm.Image);
                await _productService.CreateProduct(dto);
                return Ok(new { Message = "Created" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error creating product controller: {ex.Message}");
            }

        }

        [HttpPut("{id}")]
        [Consumes("multipart/form-data")]
        public async Task<IActionResult> UpdateProduct(int id, [FromForm] ProductUpdateViewModel vm)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var product = await _productService.GetProductById(id);
            if (product == null)
                return NotFound("Product Not Found");

            try
            {
                var dto = new ProductUpdateDto
                {
                    Id = vm.Id,
                    Name = vm.Name,
                    Description = vm.Description,
                    CategoryId = vm.CategoryId,
                    Quantity = vm.Quantity,
                    Price = vm.Price
                };

                if (vm.Image != null)
                {
                    dto.ImageUrl = await _cloudinaryService.UploadImageAsync(vm.Image);
                }

                await _productService.UpdateProduct(id, product, dto);
                return Ok("Message: Updated");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error updating product controller: {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var product = await _productService.GetProductById(id);
            if (product == null)
            {
                return NotFound("Product Not Found");
            }
            await _productService.DeleteProduct(product);
            return Ok("Message: Deleted");
        }
    }
}
