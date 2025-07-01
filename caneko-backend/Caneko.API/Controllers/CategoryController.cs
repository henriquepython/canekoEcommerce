using Caneko.Domain.Entities;
using Caneko.Domain.Interfaces.Service;
using Caneko.Domain.ViewModels;
using Caneko.Domain.ViewModels.Category;
using Microsoft.AspNetCore.Mvc;

namespace Caneko.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService ?? throw new ArgumentNullException(nameof(categoryService), "Product service cannot be null");
        }
        
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Category>>> GetAll()
        {
            try
            {
                var products = await _categoryService.GetAll();
                return Ok(products);

            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet("filter")]
        public async Task<ActionResult<CategoryOutputFilterPaginationViewModel>> Filter([FromQuery] CategoryInputFilterViewModel filter)
        {
            try
            {
                var products = await _categoryService.Filter(filter);
                return Ok(products);

            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CategoryViewModel>> GetById(string id)
        {
            try
            {
                var product = await _categoryService.FindOne(id);
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
        public async Task<ActionResult<CategoryViewModel>> Create([FromBody] CategoryCreateViewModel product)
        {
            if (product == null)
            {
                return BadRequest("Product cannot be null.");
            }

            try
            {
                var createdProduct = await _categoryService.Create(product);
                return Ok(createdProduct);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<CategoryViewModel>> Update(string id, [FromBody] CategoryUpdateViewModel product)
        {
            if (product == null)
            {
                return BadRequest("Product cannot be null.");
            }

            try
            {
                var updatedProduct = await _categoryService.Update(id, product);
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
                await _categoryService.Delete(id);
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
                await _categoryService.Disable(input.Id, input.IsDisable);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Internal server error: {ex.Message}");
            }
        }

    }
}
