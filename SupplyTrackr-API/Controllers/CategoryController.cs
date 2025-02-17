using Microsoft.AspNetCore.Mvc;
using SupplyTrackr_API.Models.ViewModels;
using SupplyTrackr_API.Services.Interface;

namespace SupplyTrackr_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : Controller
    {
        private readonly ICategoryService _service;

        public CategoryController(ICategoryService service)
        {
            _service = service;
        }
        // GET: api/category
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CategoryViewModel>>> GetAllCategories()
        {
            var cat = await _service.GetAllCategorysAsync();
            return Ok(cat);
        }
        // GET: api/category/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CategoryViewModel>> GetByCategoryId(int id)
        {
            var cat = await _service.GetCategoryByIdAsync(id);
            if (cat == null)
            {
                return NotFound();
            }
            return Ok(cat);
        }
        // POST: api/category
        [HttpPost]
        public async Task<IActionResult> AddCategoryr([FromBody] CategoryViewModel categoryViewModel)
        {
            if (await _service.AddCategoryAsync(categoryViewModel))
            {
                return Ok(new { message = "Category added successfully." });
            }
            return BadRequest(new { message = "Failed to add Category." });
        }

        // PUT: api/category/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCategory(int id, [FromBody] CategoryViewModel categoryViewModel)
        {
            if (id != categoryViewModel.CategoryId)
            {
                return BadRequest("ID mismatch.");
            }

            if (await _service.UpdateCategoryAsync(categoryViewModel))
            {
                return Ok(new { message = "category updated successfully." });
            }
            return NotFound(new { message = "category not found." });
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            if (await _service.DeleteCategoryAsync(id))
            {
                return Ok(new { message = "Category deleted successfully." });
            }
            return NotFound(new { message = "Category not found." });
        }

    }
}
