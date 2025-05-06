using cafe.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace cafe.Pages.Foods;

public class IndexModel : PageModel
{
    public readonly IFoodService FoodService;

    public List<Meal> Meals = new List<Meal>();

    public IndexModel(IFoodService foodService)
    {
        FoodService = foodService;
    }

    public void OnGet()
    {
    }
}

public class Meal
{
    public string Name { get; set; }

    public bool IsVegan { get; set; }
}