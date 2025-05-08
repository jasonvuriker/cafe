using cafe.Application.Services;
using MediatR;

namespace cafe.Application.Auth.SignIn;

public class SignInCommand(SignInRequestDto request) : IRequest<SignInResponseDto>
{
    public SignInRequestDto Request { get; } = request;
}

public class SignInCommandHandler(IAuthService authService) : IRequestHandler<SignInCommand, SignInResponseDto>
{
    public async Task<SignInResponseDto> Handle(SignInCommand request, CancellationToken cancellationToken)
    {
        var token = authService.GetToken(request.Request.Username);

        return new SignInResponseDto()
        {
            AccessToken = token,
        };
    }
}
