using cafe.Application.Auth.SignIn;
using cafe.Application.Auth.SignUp;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace cafe.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthController(IMediator mediator) : ControllerBase
{
    [HttpPost("/sign-in")]
    public async Task<IActionResult> SignIn([FromBody] SignInRequestDto request)
    {
        return Ok(await mediator.Send(new SignInCommand(request)));
    }

    [HttpPost("/sign-up")]
    public async Task<IActionResult> SignUp([FromBody] SignUpRequestDto request)
    {
        return Ok(await mediator.Send(new SignUpCommand(request)));
    }
}
