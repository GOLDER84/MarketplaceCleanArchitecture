using Microsoft.AspNetCore.Mvc;
using Mraketplace.Presention.DTOs.RequestModels;
using Mraketplace.Presention.DTOs.ResponseModels;
using Service;
using Marketplace.Domain;
using System.Threading.Tasks;

[ApiController]
[Route("user-apis")]
public class UsersController : ControllerBase
{
    private readonly IUserService _userService;

    public UsersController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpGet("get-user-summary")]
    public async Task<IActionResult> GetUserSummary([FromQuery] string name)
    {
        if (string.IsNullOrWhiteSpace(name)) return BadRequest("name is required");
        var user = await _userService.GetUserByNameAsync(name);
        var dto = UserSummaryResponseModel.FromDomain(user);
        if (dto == null) return NotFound();
        return Ok(dto);
    }

    [HttpPost("login")]
    public async Task<IActionResult> LoginUser([FromBody] LoginRequestModel loginRequest)
    {
        if (loginRequest == null) return BadRequest();
        var result = await _userService.LoginAsync(loginRequest.username, loginRequest.password);
        return Ok(result);
    }

    // Fixed: use POST + FromBody for complex DTO binding
    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] RegisterRequestModel request)
    {
        if (request == null) return BadRequest();
        var result = await _userService.RegisterAsync(request.name, request.username, request.password, request.age, request.credit, request.email);
        return Ok(result);
    }

    [HttpPut("edit")]
    public async Task<IActionResult> Edit([FromBody] EditRequestModel request)
    {
        if (request == null) return BadRequest();
        var result = await _userService.EditAsync(request.Name, request.Username, request.Password, request.Age, request.Email);
        return Ok(result);
    }

    [HttpPut("add-credit")]
    public async Task<IActionResult> AddCredit([FromBody] AddCreditRequestModel request)
    {
        if (request == null) return BadRequest();
        var result = await _userService.AddCreditAsync(request.Username, request.Amount);
        return Ok(result);
    }

    [HttpGet("get-all-users")]
    public async Task<IActionResult> GetAllUsers()
    {
        var result = await _userService.GetAllUsersAsync();
        return Ok(result);
    }
}