using Caneko.Domain.Entities;
using Caneko.Domain.Interfaces.Service;
using Caneko.Domain.ViewModels.Product;
using Microsoft.AspNetCore.Mvc;

namespace Caneko.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService ?? throw new ArgumentNullException(nameof(productService), "Product service cannot be null");
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> GetAll()
        {
            try
            {
                var products = await _productService.GetAll();
                return Ok(products);

            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet("filter")]
        public async Task<ActionResult<ProductOutputFilterPaginationViewModel>> Filter([FromQuery] ProductInputFilterViewModel filter)
        {
            try
            {
                var products = await _productService.Filter(filter);
                return Ok(products);

            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProductViewModel>> GetById(string id)
        {
            try
            {
                var product = await _productService.FindOne(id);
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
        public async Task<ActionResult<ProductViewModel>> Create([FromBody] ProductCreateViewModel product)
        {
            if (product == null)
            {
                return BadRequest("Product cannot be null.");
            }

            try
            {
                var createdProduct = await _productService.Create(product);
                return Ok(createdProduct);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<ProductViewModel>> Update(string id, [FromBody] ProductUpdateViewModel product)
        {
            if (product == null)
            {
                return BadRequest("Product cannot be null.");
            }

            try
            {
                var updatedProduct = await _productService.Update(id, product);
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
                await _productService.Delete(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPost("disable")]
        public async Task<IActionResult> DisableProduct([FromBody] ProductDisableInputViewModel input)
        {
            try
            {
                await _productService.Disable(input.Id, input.IsDisable);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Internal server error: {ex.Message}");
            }
        }
    }
}
