using Microsoft.AspNetCore.Mvc;
using SupplyTrackr_API.Models;
using SupplyTrackr_API.Models.ViewModels;
using SupplyTrackr_API.Services.Interface;
using System.Linq.Expressions;

namespace SupplyTrackr_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PurchaseOrderController : ControllerBase
    {
        private readonly IPurchaseOrderService _purchaseOrderService;
        public PurchaseOrderController(IPurchaseOrderService purchaseOrderService)
        {
            _purchaseOrderService = purchaseOrderService;
        }
        // POST: api/purchaseorder
        [HttpPost]
        public async Task<ActionResult<bool>> CreatePurchaseOrder([FromBody] PurchaseOrderViewModel purchaseOrder)
        {
            if (purchaseOrder == null)
            {
                return BadRequest("Purchase order data is required.");
            }

            var result = await _purchaseOrderService.AddPurchaseOrderAsync(purchaseOrder);
            if (result)
            {
                return Ok(true);
            }
            return StatusCode(500, "Failed to create purchase order.");
        }
        // PUT: api/purchaseorder/{id}
        [HttpPut("{id}")]
        public async Task<ActionResult<bool>> UpdatePurchaseOrder(int id, [FromBody] PurchaseOrderViewModel purchaseOrder)
        {
            if (purchaseOrder == null || id != purchaseOrder.Id)
            {
                return BadRequest("Invalid purchase order data.");
            }

            var result = await _purchaseOrderService.UpdatePurchaseOrderAsync(purchaseOrder);
            if (result)
            {
                return Ok(true);
            }
            return StatusCode(500, "Failed to update purchase order.");
        }

        // DELETE: api/purchaseorder/{id}
        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> DeletePurchaseOrder(int id)
        {
            var result = await _purchaseOrderService.DeletePurchaseOrderAsync(id);
            if (result)
            {
                return Ok(true);
            }
            return NotFound($"Purchase order with ID {id} not found.");
        }


        // GET: api/purchaseorder/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<PurchaseOrderViewModel>> GetPurchaseOrderById(int id)
        {
            var purchaseOrder = await _purchaseOrderService.GetPurchaseOrderByIdAsync(id);
            if (purchaseOrder == null)
            {
                return NotFound($"Purchase order with ID {id} not found.");
            }
            return Ok(purchaseOrder);
        }

        // GET: api/purchaseorder
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PurchaseOrderViewModel>>> GetAllPurchaseOrders()
        {
            var purchaseOrders = await _purchaseOrderService.GetAllPurchaseOrdersAsync();
            return Ok(purchaseOrders);
        }
        // GET: api/purchaseorder/condition
        [HttpGet("condition")]
        public async Task<ActionResult<IEnumerable<PurchaseOrderViewModel>>> GetPurchaseOrdersByCondition([FromQuery] string? status)
        {
            Expression<Func<PurchaseOrderViewModel, bool>> condition = po => status == null || po.OrderStatus == status;

            var purchaseOrders = await _purchaseOrderService.GetPurchaseOrdersByConditionAsync(condition);

            if (!purchaseOrders.Any())
            {
                return NotFound("No purchase orders match the given condition.");
            }

            return Ok(purchaseOrders);
        }
    }
}
