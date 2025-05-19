using System.Linq.Expressions;
using cafe.Application.FoodType.GetFoodType;
using cafe.Infrastructure.DataAccess.Repositories.Interfaces;
using MediatR;

namespace cafe.Application.FoodType.CreateFoodType;

public class CreateFoodTypeCommand(string name) : IRequest<FoodTypeDto>
{
    public string Name { get; } = name;
}

public class CreateFoodTypeCommandHandler(IFoodTypeRepository foodTypeRepository, IMediator mediator) : IRequestHandler<CreateFoodTypeCommand, FoodTypeDto>
{
    public async Task<FoodTypeDto> Handle(CreateFoodTypeCommand request, CancellationToken cancellationToken)
    {
        var entity = new Domain.Entities.FoodType()
        {
            Name = request.Name,
            IsActive = true,
        };

        await foodTypeRepository.AddAsync(entity);

        await foodTypeRepository.SaveChangesAsync();

        return new FoodTypeDto()
        {
            FoodTypeId = entity.FoodTypeId,
            Name = entity.Name,
        };
    }
}