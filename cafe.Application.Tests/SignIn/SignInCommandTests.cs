using cafe.Application.Auth.SignIn;
using cafe.Application.Services;
using cafe.Domain.Entities;
using cafe.Domain.Services;
using cafe.Infrastructure.DataAccess.Repositories.Interfaces;
using Moq;
using Moq.AutoMock;

namespace cafe.Application.Tests.SignIn;
public class SignInCommandTests
{
    private readonly AutoMocker _mocker = new();

    [Fact]
    public async Task SignIn_ValidInput_ReturnsToken()
    {
        // Arrange
        var command = new SignInCommand(new SignInRequestDto()
        {
            Username = "test",
            Password = "test"
        });

        var user = new User()
        {
            Username = "test",
        };

        var token = "testToken";

        _mocker.GetMock<IUserRepository>()
            .Setup(r => r.GetByUsernameAsync(It.IsAny<string>()))
            .ReturnsAsync(user);

        _mocker.GetMock<IPasswordHasher>()
            .Setup(r => r.VerifyHash(It.IsAny<string>(), It.IsAny<string>()))
            .Returns(true);

        _mocker.GetMock<IAuthService>()
            .Setup(r => r.GetToken(It.IsAny<int>(), It.IsAny<string>()))
            .ReturnsAsync(token);

        var handler = _mocker.CreateInstance<SignInCommandHandler>();

        // Act

        var result = await handler.Handle(command, CancellationToken.None);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(result.AccessToken, token);
    }

    [Fact]
    public async Task SignIn_InvalidUsername_ThrowsException()
    {
        // Arrange
        var command = new SignInCommand(new SignInRequestDto()
        {
            Username = "invalid",
            Password = "test"
        });

        _mocker.GetMock<IUserRepository>()
            .Setup(r => r.GetByUsernameAsync(It.IsAny<string>()))
            .ReturnsAsync((User)null);

        var handler = _mocker.CreateInstance<SignInCommandHandler>();

        // Act & Assert
        await Assert.ThrowsAsync<Exception>(() => handler.Handle(command, CancellationToken.None));
    }
}
