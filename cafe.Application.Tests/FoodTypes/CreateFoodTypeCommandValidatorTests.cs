using cafe.Application.FoodType.CreateFoodType;
using FluentValidation;

namespace cafe.Application.Tests.FoodTypes;

public class CreateFoodTypeCommandValidatorTests
{
    public CreateFoodTypeCommandValidatorTests()
    {
        
    }

    [Fact]
    public void Validate_ValidInput_ShouldSucceed()
    {
        // Arrange
        var command = new CreateFoodTypeCommand("Pizza");
        var validator = new CreateFoodTypeCommandValidator();

        // Act
        var result = validator.Validate(command);

        // Assert
        Assert.True(result.IsValid);
    }

    [Fact]
    public void Validate_InvalidInput_ShouldFail()
    {
        // Arrange
        var command = new CreateFoodTypeCommand(string.Empty);
        var validator = new CreateFoodTypeCommandValidator();

        // Act
        var result = validator.Validate(command);

        // Assert
        Assert.False(result.IsValid);
        Assert.Contains(result.Errors, e => e.PropertyName == nameof(CreateFoodTypeCommand.Name));
    }
}
