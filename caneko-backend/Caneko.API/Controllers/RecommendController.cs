using Caneko.Domain.Entities;
using Caneko.Domain.Interfaces.Service;
using Caneko.Domain.ViewModels;
using Caneko.Domain.ViewModels.Recommend;
using Microsoft.AspNetCore.Mvc;

namespace Caneko.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecommendController : ControllerBase
    {
        private readonly IRecommendService _recommendService;

        public RecommendController(IRecommendService recommendService)
        {
            _recommendService = recommendService ?? throw new ArgumentNullException(nameof(recommendService), "Product service cannot be null");
        }
        
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Recommend>>> GetAll()
        {
            try
            {
                var products = await _recommendService.GetAll();
                return Ok(products);

            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet("filter")]
        public async Task<ActionResult<RecommendOutputFilterPaginationViewModel>> Filter([FromQuery] RecommendInputFilterViewModel filter)
        {
            try
            {
                var products = await _recommendService.Filter(filter);
                return Ok(products);

            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<RecommendViewModel>> GetById(string id)
        {
            try
            {
                var product = await _recommendService.FindOne(id);
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
        public async Task<ActionResult<RecommendViewModel>> Create([FromBody] RecommendCreateViewModel product)
        {
            if (product == null)
            {
                return BadRequest("Product cannot be null.");
            }

            try
            {
                var createdProduct = await _recommendService.Create(product);
                return Ok(createdProduct);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<RecommendViewModel>> Update(string id, [FromBody] RecommendUpdateViewModel product)
        {
            if (product == null)
            {
                return BadRequest("Product cannot be null.");
            }

            try
            {
                var updatedProduct = await _recommendService.Update(id, product);
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
                await _recommendService.Delete(id);
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
                await _recommendService.Disable(input.Id, input.IsDisable);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Internal server error: {ex.Message}");
            }
        }

    }
}
