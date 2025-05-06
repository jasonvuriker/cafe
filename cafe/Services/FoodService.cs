namespace cafe.Services;

public interface IFoodService
{
    List<string> GetMeals();
}

public class FoodService : IFoodService
{
    public List<string> GetMeals()
    {
        return new()
        {
            "Pasta",
            "Pizza",
            "Burger",
            "Salad",
            "Sushi",
            "Tacos",
            "Steak",
            "Sandwich",
            "Pilaff"
        };
    }
}
