using Application.Users.GetUsers;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Refit;

namespace API.Controllers;

[ApiController]
[Route("/api")]
public class UsersController : ControllerBase
{
    private readonly IMediator _mediator;

    public UsersController(IMediator mediator)
    {
        this._mediator = mediator;
    }

    [HttpGet("get-users")]
    public async Task<IActionResult> GetUsers(int page)
    {
        try
        {
            GetUsersQuery query = new GetUsersQuery()
            {
                page = page
            };

            var response = await _mediator.Send(query);
            return Ok(response);
        }
        catch (Exception ex)
        {
            return StatusCode(500);
        }
    }
}
