using Microsoft.AspNetCore.Mvc;
using SupplyTrackr_API.Models;
using SupplyTrackr_API.Models.ViewModels;
using System.Linq.Expressions;

namespace SupplyTrackr_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : Controller
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        // GET: api/product
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductViewModel>>> GetAllProducts()
        {
            var products = await _productService.GetAllProductsAsync();
            return Ok(products);
        }
        // GET: api/product/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductViewModel>> GetProduct(int id)
        {
            var product = await _productService.GetProductByIdAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }
        // POST: api/product
        [HttpPost]
        public async Task<IActionResult> AddProduct([FromBody] ProductViewModel productViewModel)
        {
            if (await _productService.AddProductAsync(productViewModel))
            {
                return Ok(new { message = "Product added successfully." });
            }
            return BadRequest(new { message = "Failed to add product." });
        }

        // PUT: api/product/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProduct(int id, [FromBody] ProductViewModel productViewModel)
        {
            if (id != productViewModel.Id)
            {
                return BadRequest("ID mismatch.");
            }

            if (await _productService.UpdateProductAsync(productViewModel))
            {
                return Ok(new { message = "Product updated successfully." });
            }
            return NotFound(new { message = "Product not found." });
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            if (await _productService.DeleteProductAsync(id))
            {
                return Ok(new { message = "Product deleted successfully." });
            }
            return NotFound(new { message = "Product not found." });
        }

        // GET: api/product/condition?status=Active
        [HttpGet("condition")]
        public async Task<ActionResult<IEnumerable<ProductViewModel>>> GetProductsByCondition([FromQuery] string status)
        {
            Expression<Func<Product, bool>> condition = p => p.Status == status;
            var products = await _productService.GetProductsByConditionAsync(condition);
            return Ok(products);
        }
    }
}
