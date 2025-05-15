using cafe.Application.FoodType.CreateFoodType;
using cafe.Application.FoodType.GetFoodType;
using cafe.Domain.Enums;
using cafe.WebApi.Auth;
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
    [RequirePermission(PermissionType.ViewFoodPermission)]
    public async Task<IActionResult> GetFoodTypes()
    {
        return Ok(await mediator.Send(new GetFoodTypesQuery()));
    }

    [HttpGet("{id}")]
    [RequirePermission(PermissionType.ViewFoodPermission)]
    public async Task<IActionResult> GetFoodType(int id)
    {
        var result = await mediator.Send(new GetFoodTypeQuery(id));
        if (result is null)
        {
            return NotFound();
        }

        return Ok(result);
    }

    [HttpPost]
    [RequirePermission(PermissionType.InsertFoodPermission)]
    public async Task<IActionResult> CreateFoodType([FromBody] CreateFoodTypeCommand command)
    {
        await mediator.Send(command);

        return Ok();
    }
}
