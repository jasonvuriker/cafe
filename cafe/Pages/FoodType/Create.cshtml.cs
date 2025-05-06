using cafe.Application.FoodType.CreateFoodType;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace cafe.Pages.FoodType
{
    public class CreateModel(IMediator mediator) : PageModel
    {
        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPost(string foodTypeName)
        {
            await mediator.Send(new CreateFoodTypeCommand(foodTypeName));

            return RedirectToPage("/FoodType/Index");
        }
    }
}
