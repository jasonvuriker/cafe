using cafe.Infrastructure.DataAccess.Repositories.Interfaces;
using MediatR;

namespace cafe.Application.FoodType.GetFoodType;

public class GetFoodTypeQuery : IRequest<IList<FoodTypeDto>>;

public class GetFoodTypeQueryHandler(IFoodTypeRepository foodTypeRepository) : IRequestHandler<GetFoodTypeQuery, IList<FoodTypeDto>>
{
    public async Task<IList<FoodTypeDto>> Handle(GetFoodTypeQuery request, CancellationToken cancellationToken)
    {
        var result = foodTypeRepository.GetAll()
            .Select(r => new FoodTypeDto()
            {
                Name = r.Name,
                FoodTypeId = r.FoodTypeId,
            })
            .ToList();

        return result;
    }
}

