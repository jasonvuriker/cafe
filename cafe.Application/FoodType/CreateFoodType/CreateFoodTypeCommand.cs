using cafe.Infrastructure.DataAccess.Repositories.Interfaces;
using MediatR;

namespace cafe.Application.FoodType.CreateFoodType;

public class CreateFoodTypeCommand(string name) : IRequest
{
    public string Name { get; } = name;
}

public class CreateFoodTypeCommandHandler(IFoodTypeRepository foodTypeRepository) : IRequestHandler<CreateFoodTypeCommand>
{
    public async Task Handle(CreateFoodTypeCommand request, CancellationToken cancellationToken)
    {
        await foodTypeRepository.AddAsync(new Domain.Entities.FoodType()
        {
            Name = request.Name,
            IsActive = true,
        });

        await foodTypeRepository.SaveChangesAsync();
    }
}