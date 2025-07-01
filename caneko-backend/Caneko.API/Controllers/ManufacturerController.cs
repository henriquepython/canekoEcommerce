using Caneko.Domain.Entities;
using Caneko.Domain.Interfaces.Service;
using Caneko.Domain.ViewModels;
using Caneko.Domain.ViewModels.Manufacturer;
using Microsoft.AspNetCore.Mvc;

namespace Caneko.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ManufacturerController : ControllerBase
    {
        private readonly IManufacturerService _manufacturerService;

        public ManufacturerController(IManufacturerService manufacturerService)
        {
            _manufacturerService = manufacturerService ?? throw new ArgumentNullException(nameof(manufacturerService), "Product service cannot be null");
        }
        
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Manufacturer>>> GetAll()
        {
            try
            {
                var products = await _manufacturerService.GetAll();
                return Ok(products);

            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet("filter")]
        public async Task<ActionResult<ManufacturerOutputFilterPaginationViewModel>> Filter([FromQuery] ManufacturerInputFilterViewModel filter)
        {
            try
            {
                var products = await _manufacturerService.Filter(filter);
                return Ok(products);

            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ManufacturerViewModel>> GetById(string id)
        {
            try
            {
                var product = await _manufacturerService.FindOne(id);
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
        public async Task<ActionResult<ManufacturerViewModel>> Create([FromBody] ManufacturerCreateViewModel product)
        {
            if (product == null)
            {
                return BadRequest("Product cannot be null.");
            }

            try
            {
                var createdProduct = await _manufacturerService.Create(product);
                return Ok(createdProduct);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<ManufacturerViewModel>> Update(string id, [FromBody] ManufacturerUpdateViewModel product)
        {
            if (product == null)
            {
                return BadRequest("Product cannot be null.");
            }

            try
            {
                var updatedProduct = await _manufacturerService.Update(id, product);
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
                await _manufacturerService.Delete(id);
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
                await _manufacturerService.Disable(input.Id, input.IsDisable);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Internal server error: {ex.Message}");
            }
        }

    }
}
