using FluentValidation;

namespace cafe.Application.FoodType.CreateFoodType;

public class CreateFoodTypeCommandValidator : AbstractValidator<CreateFoodTypeCommand>
{
    public CreateFoodTypeCommandValidator()
    {
        RuleFor(r => r.Name)
            .MinimumLength(2)
            .MaximumLength(100);
    }
}
