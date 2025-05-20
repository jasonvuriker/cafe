//using cafe.Domain.Entities;
//using cafe.Infrastructure.DataAccess.Repositories;
//using cafe.Infrastructure.DataAccess.Repositories.Interfaces;
//using Microsoft.EntityFrameworkCore.Internal;
//using Moq.AutoMock;

//namespace cafe.DataAccess.UnitTests.Repository;

//public class FoodTypeRepositoryTests
//{
//    private readonly AutoMocker _mocker = new();

//    [Fact]
//    public void GetAllFoodTypes_ShouldReturnAllFoodTypes()
//    {
//        // Arrange
//        var repository = _mocker.CreateInstance<IFoodTypeRepository>();
//        var expectedFoodTypes = new List<FoodType>
//        {
//            new FoodType { FoodTypeId = 1, Name = "Pizza" },
//            new FoodType { FoodTypeId = 2, Name = "Burger" },
//            new FoodType { FoodTypeId = 3, Name = "Pasta" }
//        };

//        _mocker.GetMock<CafeDbContext>()
//            .Setup(r => r.FoodTypes)
//            .Returns(()

//        // Act
//        var result = repository.GetAll();

//        Assert.Equal();
//    }
