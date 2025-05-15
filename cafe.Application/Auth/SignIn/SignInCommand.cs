using cafe.Application.Services;
using cafe.Domain.Services;
using cafe.Infrastructure.DataAccess.Repositories.Interfaces;
using MediatR;

namespace cafe.Application.Auth.SignIn;

public class SignInCommand(SignInRequestDto request) : IRequest<SignInResponseDto>
{
    public SignInRequestDto Request { get; } = request;
}

public class SignInCommandHandler(
    IUserRepository userRepository,
    IAuthService authService,
    IPasswordHasher passwordHasher)
    : IRequestHandler<SignInCommand, SignInResponseDto>
{
    public async Task<SignInResponseDto> Handle(SignInCommand command, CancellationToken cancellationToken)
    {
        var request = command.Request;

        var user = await userRepository.GetByUsernameAsync(request.Username);
        if (user is null)
        {
            throw new UnauthorizedAccessException("Invalid username or password.");
        }

        var isValidPassword = passwordHasher.VerifyHash(request.Password, user.PasswordHash);
        if (!isValidPassword)
        {
            throw new UnauthorizedAccessException("Invalid username or password.");
        }

        var token = await authService.GetToken(user.UserId, request.Username);

        return new SignInResponseDto()
        {
            AccessToken = token,
        };
    }
}
