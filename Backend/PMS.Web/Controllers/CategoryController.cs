using Microsoft.AspNetCore.Mvc;
using PMS.Core;
using PMS.Core.CategoryFeatures;

namespace PMS.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly CategoryService _categoryService;

        public CategoryController(CategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet]
        public async Task<IActionResult> GetCategories()
        {
            var list = await _categoryService.GetAllCategories();
            return Ok(list);

        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCategories(int id)
        {
            var category = await _categoryService.GetCategoryById(id);
            return Ok(category);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCategory([FromBody] CategoryCreateDto dto)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            await _categoryService.CreateCategory(dto);
            return Ok("Message: Created");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCategory(int id, [FromBody] CategoryUpdateDto dto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var category = await _categoryService.GetCategoryById(id);
            if(category == null)
            {
                return NotFound("Category Not Found");
            }
            await _categoryService.UpdateCategory(id,category,dto);
            return Ok("Message: Updated");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            var category = await _categoryService.GetCategoryById(id);
            if (category == null)
            {
                return NotFound("Category Not Found");
            }
            await _categoryService.DeleteCategory(category);
            return Ok("Message: Deleted");
        }
    }
}
