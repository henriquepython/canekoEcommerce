using Caneko.Domain.Interfaces.Service;
using Caneko.Domain.ViewModels;
using Caneko.Domain.ViewModels.ColorItem;
using Microsoft.AspNetCore.Mvc;

namespace Caneko.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ColorItemController : ControllerBase
    {
        private readonly IColorItemService _colorItemService;

        public ColorItemController(IColorItemService colorItemService)
        {
            _colorItemService = colorItemService ?? throw new ArgumentNullException(nameof(colorItemService), "Service cannot be null");
        }
        
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ColorItemViewModel>>> GetAll()
        {
            try
            {
                var items = await _colorItemService.GetAll();
                return Ok(items);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet("filter")]
        public async Task<ActionResult<ColorItemOutputFilterPaginationViewModel>> Filter([FromQuery] ColorItemInputFilterViewModel filter)
        {
            try
            {
                var items = await _colorItemService.Filter(filter);
                return Ok(items);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ColorItemViewModel>> GetById(string id)
        {
            try
            {
                var item = await _colorItemService.FindOne(id);
                if (item == null)
                {
                    return NotFound($"Item with ID {id} not found.");
                }
                return Ok(item);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPost]
        public async Task<ActionResult<ColorItemViewModel>> Create([FromBody] ColorItemCreateViewModel item)
        {
            if (item == null)
            {
                return BadRequest("Item cannot be null.");
            }
            try
            {
                var created = await _colorItemService.Create(item);
                return Ok(created);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<ColorItemViewModel>> Update(string id, [FromBody] ColorItemUpdateViewModel item)
        {
            if (item == null)
            {
                return BadRequest("Item cannot be null.");
            }
            try
            {
                var updated = await _colorItemService.Update(id, item);
                if (updated == null)
                {
                    return NotFound($"Item with ID {id} not found.");
                }
                return Ok(updated);
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
                await _colorItemService.Delete(id);
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
                await _colorItemService.Disable(input.Id, input.IsDisable);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Internal server error: {ex.Message}");
            }
        }
    }
}
