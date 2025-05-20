using AutoMapper;
using cafe.Infrastructure.DataAccess.Repositories.Interfaces;
using MediatR;

namespace cafe.Application.Food.CreateFood;

public class CreateFoodCommand(CreateFoodRequestDto request) : IRequest<CreateFoodResponseDto>
{
    public CreateFoodRequestDto Request { get; } = request;
}

public class CreateFoodCommandHandler(IFoodRepository foodRepository, IMapper mapper)
    : IRequestHandler<CreateFoodCommand, CreateFoodResponseDto>
{
    public async Task<CreateFoodResponseDto> Handle(CreateFoodCommand request, CancellationToken cancellationToken)
    {
        var entity = mapper.Map<Domain.Entities.Food>(request.Request);

        await foodRepository.AddAsync(entity);
        await foodRepository.SaveChangesAsync();

        return new CreateFoodResponseDto()
        {
            FoodId = entity.FoodId,
            Name = entity.Name,
            FoodTypeId = entity.FoodTypeId,
            IsActive = entity.IsActive,
            Ingredients = entity.Ingredients
        };
    }
}
