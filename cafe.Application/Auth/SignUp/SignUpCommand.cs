using cafe.Domain.Entities;
using cafe.Domain.Services;
using cafe.Infrastructure.DataAccess.Repositories.Interfaces;
using MediatR;

namespace cafe.Application.Auth.SignUp;

public class SignUpCommand(SignUpRequestDto request) : IRequest<SignUpResponseDto>
{
    public SignUpRequestDto Request { get; } = request;
}

public class SignUpCommandHandler(IUserRepository userRepository, IPasswordHasher passwordHasher) : IRequestHandler<SignUpCommand, SignUpResponseDto>
{
    public async Task<SignUpResponseDto> Handle(SignUpCommand command, CancellationToken cancellationToken)
    {
        var request = command.Request;

        var user = new User()
        {
            Username = request.Username,
            Email = request.Email,
            PasswordHash = passwordHasher.HashPassword(request.Password),
            IsActive = true,
            RoleId = 2,
        };

        await userRepository.AddAsync(user);
        await userRepository.SaveChangesAsync();

        return new SignUpResponseDto()
        {
            Username = user.Username,
            PasswordHash = user.PasswordHash,
            Email = user.Email,
        };
    }
}