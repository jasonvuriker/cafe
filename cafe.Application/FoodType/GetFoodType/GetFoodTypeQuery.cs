using cafe.Application.Exceptions;
using cafe.Infrastructure.DataAccess.Repositories.Interfaces;
using MediatR;

namespace cafe.Application.FoodType.GetFoodType;

public class GetFoodTypeQuery(int id) : IRequest<FoodTypeDto>
{
    public int Id { get; } = id;
}

public class GetFoodTypeQueryHandler(IFoodTypeRepository foodTypeRepository) : IRequestHandler<GetFoodTypeQuery, FoodTypeDto>
{
    public async Task<FoodTypeDto> Handle(GetFoodTypeQuery request, CancellationToken cancellationToken)
    {
        var result = await foodTypeRepository.GetByIdAsync(request.Id);

        if (result is null)
        {
            throw new FoodTypeNotFoundException(request.Id);
        }

        return new FoodTypeDto()
        {
            FoodTypeId = result.FoodTypeId,
            Name = result.Name,
        };
    }
}
