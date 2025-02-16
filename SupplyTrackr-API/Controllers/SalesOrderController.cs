using Microsoft.AspNetCore.Mvc;
using SupplyTrackr_API.Models.ViewModels;
using SupplyTrackr_API.Services.Interface;

namespace SupplyTrackr_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SalesOrderController : Controller
    {
        private readonly ISalesOrderService _service;

        public SalesOrderController(ISalesOrderService service)
        {
            _service = service;
        }

        // GET: api/product
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SalesOrderViewModel>>> GetAllProducts()
        {
            var products = await _service.GetAllSalesOrdersAsync();
            return Ok(products);
        }
        // GET: api/product/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SalesOrderViewModel>> GetByOrderId(int id)
        {
            var product = await _service.GetSalesOrderByIdAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }
        // POST: api/product
        [HttpPost]
        public async Task<IActionResult> AddCreateOrder([FromBody] SalesOrderViewModel salesViewModel)
        {
            if (await _service.CreateSalesOrderAsync(salesViewModel))
            {
                return Ok(new { message = "Product added successfully." });
            }
            return BadRequest(new { message = "Failed to add product." });
        }

        // PUT: api/product/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOrder(int id, [FromBody] SalesOrderViewModel salesViewModel)
        {
            if (id != salesViewModel.OrderId)
            {
                return BadRequest("ID mismatch.");
            }

            if (await _service.UpdateSalesOrderAsync(salesViewModel))
            {
                return Ok(new { message = "Product updated successfully." });
            }
            return NotFound(new { message = "Product not found." });
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            if (await _service.DeleteSalesOrderAsync(id))
            {
                return Ok(new { message = "Product deleted successfully." });
            }
            return NotFound(new { message = "Product not found." });
        }

    }
}
