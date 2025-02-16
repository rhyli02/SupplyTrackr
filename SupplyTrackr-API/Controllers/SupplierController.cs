using Microsoft.AspNetCore.Mvc;
using SupplyTrackr_API.Models.ViewModels;
using SupplyTrackr_API.Models;
using SupplyTrackr_API.Services.Interface;
using System.Linq.Expressions;

namespace SupplyTrackr_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SupplierController : Controller
    {
        private readonly ISupplierService _service;

        public SupplierController(ISupplierService service)
        {
            _service = service;
        }
        // GET: api/product
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SupplierViewModel>>> GetAllSuppliers()
        {
            var suppliers = await _service.GetAllSuppliersAsync();
            return Ok(suppliers);
        }
        // GET: api/product/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SupplierViewModel>> GetSupplier(int id)
        {
            var product = await _service.GetSupplierByIdAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }
        // POST: api/product
        [HttpPost]
        public async Task<IActionResult> AddSupplier([FromBody] SupplierViewModel supplierViewModel)
        {
            if (await _service.AddSupplierAsync(supplierViewModel))
            {
                return Ok(new { message = "Supplier added successfully." });
            }
            return BadRequest(new { message = "Failed to add product." });
        }

        // PUT: api/product/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSupplier(int id, [FromBody] SupplierViewModel supplierViewModel)
        {
            if (id != supplierViewModel.Id)
            {
                return BadRequest("ID mismatch.");
            }

            if (await _service.UpdateSupplierAsync(supplierViewModel))
            {
                return Ok(new { message = "Supplier updated successfully." });
            }
            return NotFound(new { message = "Supplier not found." });
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSupplier(int id)
        {
            if (await _service.DeleteSupplierAsync(id))
            {
                return Ok(new { message = "Supplier deleted successfully." });
            }
            return NotFound(new { message = "Supplier not found." });
        }

        // GET: api/product/condition?status=Active
        [HttpGet("condition")]
        public async Task<ActionResult<IEnumerable<SupplierViewModel>>> GetSuppliersByCondition([FromQuery] string name)
        {
            Expression<Func<Supplier, bool>> condition = p => p.CompanyName == name;
            var suppliers = await _service.GetSuppliersByConditionAsync(condition);
            return Ok(suppliers);
        }
    }
}
