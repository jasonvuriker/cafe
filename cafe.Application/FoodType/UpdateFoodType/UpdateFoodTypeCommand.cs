using cafe.Application.Exceptions;
using cafe.Infrastructure.DataAccess.Repositories.Interfaces;
using MediatR;

namespace cafe.Application.FoodType.UpdateFoodType;

public class UpdateFoodTypeCommand(int id, string name) : IRequest
{
    public int Id { get; } = id;

    public string Name { get; } = name;
}

public class UpdateFoodTypeCommandHandler(IFoodTypeRepository foodTypeRepository) : IRequestHandler<UpdateFoodTypeCommand>
{
    public async Task Handle(UpdateFoodTypeCommand command, CancellationToken cancellationToken)
    {
        var foodType = await foodTypeRepository.GetByIdAsync(command.Id);

        if (foodType is null)
        {
            throw new FoodTypeNotFoundException(command.Id);
        }

        foodType.Name = command.Name;

        await foodTypeRepository.SaveChangesAsync();
    }
}