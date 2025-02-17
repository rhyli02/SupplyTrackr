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

        // GET: api/order
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SalesOrderViewModel>>> GetAllOrders()
        {
            var orders = await _service.GetAllSalesOrdersAsync();
            return Ok(orders);
        }
        // GET: api/order/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SalesOrderViewModel>> GetByOrderId(int id)
        {
            var orders = await _service.GetSalesOrderByIdAsync(id);
            if (orders == null)
            {
                return NotFound();
            }
            return Ok(orders);
        }
        // POST: api/order
        [HttpPost]
        public async Task<IActionResult> AddCreateOrder([FromBody] SalesOrderViewModel orderViewModel)
        {
            if (await _service.CreateSalesOrderAsync(orderViewModel))
            {
                return Ok(new { message = "Sales Order added successfully." });
            }
            return BadRequest(new { message = "Failed to add order." });
        }

        // PUT: api/order/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOrder(int id, [FromBody] SalesOrderViewModel orderViewModel)
        {
            if (id != orderViewModel.OrderId)
            {
                return BadRequest("ID mismatch.");
            }

            if (await _service.UpdateSalesOrderAsync(orderViewModel))
            {
                return Ok(new { message = "Sales Order updated successfully." });
            }
            return NotFound(new { message = "Sales Order not found." });
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrder(int id)
        {
            if (await _service.DeleteSalesOrderAsync(id))
            {
                return Ok(new { message = "Sales Order deleted successfully." });
            }
            return NotFound(new { message = "Sales Order not found." });
        }

    }
}
