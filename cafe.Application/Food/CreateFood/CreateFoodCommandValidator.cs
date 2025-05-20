using FluentValidation;

namespace cafe.Application.Food.CreateFood;

public class CreateFoodCommandValidator:AbstractValidator<CreateFoodCommand>
{
    public CreateFoodCommandValidator(IValidator<CreateFoodRequestDto> requestValidator)
    {
        RuleFor(r => r.Request)
            .SetValidator(requestValidator);
    }
}
