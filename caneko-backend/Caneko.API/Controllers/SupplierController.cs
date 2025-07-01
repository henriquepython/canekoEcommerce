using Caneko.Domain.Entities;
using Caneko.Domain.Interfaces.Service;
using Caneko.Domain.ViewModels;
using Caneko.Domain.ViewModels.Supplier;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Caneko.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SupplierController : ControllerBase
    {
        private readonly ISupplierService _supplierService;

        public SupplierController(ISupplierService supplierService)
        {
            _supplierService = supplierService ?? throw new ArgumentNullException(nameof(supplierService), "Product service cannot be null");
        }
        
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Supplier>>> GetAll()
        {
            try
            {
                var products = await _supplierService.GetAll();
                return Ok(products);

            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet("filter")]
        public async Task<ActionResult<SupplierOutputFilterPaginationViewModel>> Filter([FromQuery] SupplierInputFilterViewModel filter)
        {
            try
            {
                var products = await _supplierService.Filter(filter);
                return Ok(products);

            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<SupplierViewModel>> GetById(string id)
        {
            try
            {
                var product = await _supplierService.FindOne(id);
                if (product == null)
                {
                    return NotFound($"Product with ID {id} not found.");
                }
                return Ok(product);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPost]
        public async Task<ActionResult<SupplierViewModel>> Create([FromBody] SupplierCreateViewModel product)
        {
            if (product == null)
            {
                return BadRequest("Product cannot be null.");
            }

            try
            {
                var createdProduct = await _supplierService.Create(product);
                return Ok(createdProduct);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<SupplierViewModel>> Update(string id, [FromBody] SupplierUpdateViewModel product)
        {
            if (product == null)
            {
                return BadRequest("Product cannot be null.");
            }

            try
            {
                var updatedProduct = await _supplierService.Update(id, product);
                if (updatedProduct == null)
                {
                    return NotFound($"Product with ID {id} not found.");
                }
                return Ok(updatedProduct);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Internal server error: {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            try
            {
                await _supplierService.Delete(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPost("disable")]
        public async Task<IActionResult> Disable([FromBody] DisableInputViewModel input)
        {
            try
            {
                await _supplierService.Disable(input.Id, input.IsDisable);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Internal server error: {ex.Message}");
            }
        }

    }
}
