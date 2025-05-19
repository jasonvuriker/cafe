using cafe.Application.FoodType.CreateFoodType;
using cafe.Infrastructure.DataAccess.Repositories;
using cafe.Infrastructure.DataAccess.Repositories.Interfaces;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using Moq.AutoMock;

namespace cafe.Application.Tests.FoodTypesTests;

public class CreateFoodTypeCommandTests
{
    private readonly AutoMocker _mocker = new();

    [Fact]
    public async Task CreateFoodTypeCommand_ValidInput_ShouldSuccess()
    {
        // Arrange
        var foodTypeName = "Test Food Type";
        var command = new CreateFoodTypeCommand(foodTypeName);

        var handler = _mocker.CreateInstance<CreateFoodTypeCommandHandler>();

        // Act
        var result = await handler.Handle(command, CancellationToken.None);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(foodTypeName, result.Name);

        _mocker.GetMock<IFoodTypeRepository>()
            .Verify((r)=> r.AddAsync(It.IsAny<Domain.Entities.FoodType>()), Times.Once);

        _mocker.GetMock<IFoodTypeRepository>()
            .Verify((r) => r.SaveChangesAsync(), Times.Once);
    }
}
