using AutoFixture;
using AutoMapper;
using cafe.Application.Food.CreateFood;
using cafe.Infrastructure.DataAccess.Repositories.Interfaces;
using Moq;
using Moq.AutoMock;

namespace cafe.Application.Tests.Food;
public class CreateFoodCommandTests
{
    private readonly AutoMocker _mocker = new();
    private readonly Fixture _fixture = new();

    public CreateFoodCommandTests()
    {
    }

    [Fact]
    public async Task CreateFoodCommand_ValidInput_ShouldSuccess()
    {
        // Arrange
        var request = _fixture.Create<CreateFoodRequestDto>();

        var command = new CreateFoodCommand(request);

        var handler = _mocker.CreateInstance<CreateFoodCommandHandler>();

        _mocker.GetMock<IMapper>()
            .Setup(r => r.Map<Domain.Entities.Food>(request))
            .Returns(new Domain.Entities.Food()
            {
                FoodTypeId = request.FoodTypeId,
                IsActive = request.IsActive,
                Name = request.Name,
                Ingredients = request.Ingredients,
            });

        // Act
        var result = await handler.Handle(command, CancellationToken.None);

        // Assert
        _mocker.GetMock<IMapper>()
            .Verify(m => m.Map<Domain.Entities.Food>(request), Times.Once);

        _mocker.GetMock<IFoodRepository>()
            .Verify(r => r.AddAsync(It.IsAny<Domain.Entities.Food>()), Times.Once);

        _mocker.GetMock<IFoodRepository>()
            .Verify(r => r.SaveChangesAsync(), Times.Exactly(1));

        Assert.NotNull(result);
        Assert.Equal(request.Name, result.Name);
    }
}
