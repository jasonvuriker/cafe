using cafe.Application.FoodType.GetFoodType;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace cafe.Pages.FoodType
{
    public class IndexModel(IMediator mediator) : PageModel
    {
        public IList<FoodTypeDto> FoodTypes { get; set; }

        public async Task OnGet()
        {
            FoodTypes = await mediator.Send(new GetFoodTypesQuery());
        }
    }
}
