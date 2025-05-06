namespace cafe.Domain.Entities;

public class Food
{
    public int FoodId { get; set; }

    public string Name { get; set; }

    public int FoodTypeId { get; set; }

    public bool IsActive { get; set; }

    public string[] Ingredients { get; set; } = [];
}
