namespace cafe.Application.Food.CreateFood;

public class CreateFoodRequestDto
{
    public string Name { get; set; }

    public int FoodTypeId { get; set; }

    public bool IsActive { get; set; }

    public string[] Ingredients { get; set; } = [];
}
