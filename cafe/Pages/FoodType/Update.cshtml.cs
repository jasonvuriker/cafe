using cafe.Application.FoodType.GetFoodType;
using cafe.Application.FoodType.UpdateFoodType;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace cafe.Pages.FoodType
{
    public class UpdateModel(IMediator mediator) : PageModel
    {
        [BindProperty]
        public FoodTypeDto FoodType { get; set; }

        public async Task OnGet()
        {
            var id = int.Parse(RouteData.Values["id"].ToString());

            FoodType = await mediator.Send(new GetFoodTypeQuery(id));
        }

        public async Task<IActionResult> OnPost()
        {
            await mediator.Send(new UpdateFoodTypeCommand(FoodType.FoodTypeId, FoodType.Name));

            return RedirectToPage("/FoodType/Index");
        }
    }
}
