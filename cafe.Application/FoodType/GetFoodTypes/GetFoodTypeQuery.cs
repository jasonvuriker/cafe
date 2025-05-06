using cafe.Infrastructure.DataAccess.Repositories.Interfaces;
using MediatR;

namespace cafe.Application.FoodType.GetFoodType;

public class GetFoodTypesQuery : IRequest<IList<FoodTypeDto>>;

public class GetFoodTypesQueryHandler(IFoodTypeRepository foodTypeRepository) : IRequestHandler<GetFoodTypesQuery, IList<FoodTypeDto>>
{
    public async Task<IList<FoodTypeDto>> Handle(GetFoodTypesQuery request, CancellationToken cancellationToken)
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

