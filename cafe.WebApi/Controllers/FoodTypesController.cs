using cafe.Application.FoodType.GetFoodType;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace cafe.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize]
public class FoodTypesController(IMediator mediator) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetFoodTypes()
    {
        return Ok(await mediator.Send(new GetFoodTypesQuery()));
    }
}
