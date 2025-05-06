using cafe.Domain.Exceptions;

namespace cafe.Application.Exceptions;

public class FoodTypeNotFoundException(int id) : NotFoundException($"Food type not found with id: {id}");
