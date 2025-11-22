using Microsoft.AspNetCore.Mvc;
using Mraketplace.Presention.DTOs.RequestModels;
using Mraketplace.Presention.DTOs.ResponseModels;
using Service;
using System.Linq;
using System.Threading.Tasks;

namespace Mraketplace.Presention.Controllers;

[ApiController]
[Route("item-apis")]
public class ItemsController : ControllerBase
{
    private readonly IItemService _itemService;

    public ItemsController(IItemService itemService)
    {
        _itemService = itemService;
    }

    [HttpGet("get-all")]
    public async Task<IActionResult> GetAll()
    {
        var items = await _itemService.GetAllAsync();
        var dtos = items.Select(ItemSummaryResponseModel.FromDomain);
        return Ok(dtos);
    }

    [HttpGet("get-by-id/{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var item = await _itemService.GetByIdAsync(id);
        var dto = ItemSummaryResponseModel.FromDomain(item);
        if (dto == null)
        {
            return NotFound();
        }
        return Ok(dto);
    }

    [HttpPost("add")]
    public async Task<IActionResult> Add([FromBody] AddItemRequestModel request)
    {
        if (request == null) return BadRequest();
        var result = await _itemService.AddAsync(request.Name, request.Price, request.Description);
        return Ok(result);
    }

    [HttpPost("buy")]
    public async Task<IActionResult> Buy([FromBody] BuyItemRequestModel request)
    {
        if (request == null) return BadRequest();
        var result = await _itemService.BuyAsync(request.Username, request.ItemId);
        return Ok(result);
    }

    [HttpDelete("remove/{id}")]
    public async Task<IActionResult> Remove(int id)
    {
        var result = await _itemService.RemoveAsync(id);
        return Ok(result);
    }
}