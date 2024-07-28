using CommunityEventPlanner.Application.Interfaces.Services;
using CommunityEventPlanner.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Moq;
using CommunityEventPlanner.Application.UseCases.Users.Command.LoginUser;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
namespace CommunityEventPlanner.UnitTests.Application.Commands.Handlers
{
    public class LoginUserCommandHandlerTests
    {
        private readonly Mock<UserManager<ApplicationUser>> _userManagerMock;
        private readonly Mock<SignInManager<ApplicationUser>> _signInManagerMock;
        private readonly Mock<IAuthService> _authServiceMock;
        private readonly LoginUserCommandHandler _handler;

        public LoginUserCommandHandlerTests()
        {
            var userStoreMock = new Mock<IUserStore<ApplicationUser>>();
            _userManagerMock = new Mock<UserManager<ApplicationUser>>(userStoreMock.Object, null, null, null, null, null, null, null, null);

            var contextAccessorMock = new Mock<IHttpContextAccessor>();
            var contextMock = new DefaultHttpContext();
            contextAccessorMock.Setup(x => x.HttpContext).Returns(contextMock);

            var userClaimsPrincipalFactoryMock = new Mock<IUserClaimsPrincipalFactory<ApplicationUser>>();
            var optionsMock = new Mock<IOptions<IdentityOptions>>();
            var loggerMock = new Mock<ILogger<SignInManager<ApplicationUser>>>();
            var schemesMock = new Mock<IAuthenticationSchemeProvider>();
            var confirmationMock = new Mock<IUserConfirmation<ApplicationUser>>();

            _signInManagerMock = new Mock<SignInManager<ApplicationUser>>(
                _userManagerMock.Object,
                contextAccessorMock.Object,
                userClaimsPrincipalFactoryMock.Object,
                optionsMock.Object,
                loggerMock.Object,
                schemesMock.Object,
                confirmationMock.Object);

            _authServiceMock = new Mock<IAuthService>();
            _handler = new LoginUserCommandHandler(_userManagerMock.Object, _signInManagerMock.Object, _authServiceMock.Object);
        }

        [Fact]
        public async Task Handle_ValidRequest_ShouldReturnSuccess()
        {
            // Arrange
            var request = new LoginUserCommand
            {
                Email = "cyndibilo@gmail.com",
                Password = "Password1234@"
            };

            var user = new ApplicationUser { Email = request.Email };

            _userManagerMock.Setup(x => x.FindByEmailAsync(request.Email)).ReturnsAsync(user);
            _signInManagerMock.Setup(x => x.PasswordSignInAsync(user, request.Password, false, false)).ReturnsAsync(SignInResult.Success);
            _authServiceMock.Setup(x => x.GenerateJwtToken(user)).ReturnsAsync("sample-jwt-token");

            // Act
            var result = await _handler.Handle(request, CancellationToken.None);

            // Assert
            Assert.True(result.Success);
            Assert.Equal("sample-jwt-token", result.JwtToken);
            Assert.Equal("User Logged in Sucessfully.", result.Message);
            Assert.Equal(StatusCodes.Status200OK, result.Code);
        }

        [Fact]
        public async Task Handle_InvalidEmail_ShouldReturnFailure()
        {
            // Arrange
            var request = new LoginUserCommand
            {
                Email = "invalidemail@example.com",
                Password = "Password1234@"
            };

            _userManagerMock.Setup(x => x.FindByEmailAsync(request.Email)).ReturnsAsync((ApplicationUser)null);

            // Act
            var result = await _handler.Handle(request, CancellationToken.None);

            // Assert
            Assert.False(result.Success);
            Assert.Equal("Invalid email or password.", result.Message);
            Assert.Equal(StatusCodes.Status400BadRequest, result.Code);
        }

        [Fact]
        public async Task Handle_InvalidPassword_ShouldReturnFailure()
        {
            // Arrange
            var request = new LoginUserCommand
            {
                Email = "cyndibilo@gmail.com",
                Password = "InvalidPassword!"
            };

            var user = new ApplicationUser { Email = request.Email };

            _userManagerMock.Setup(x => x.FindByEmailAsync(request.Email)).ReturnsAsync(user);
            _signInManagerMock.Setup(x => x.PasswordSignInAsync(user, request.Password, false, false)).ReturnsAsync(SignInResult.Failed);

            // Act
            var result = await _handler.Handle(request, CancellationToken.None);

            // Assert
            Assert.False(result.Success);
            Assert.Equal("Invalid email or password.", result.Message);
            Assert.Equal(StatusCodes.Status400BadRequest, result.Code);
        }
    }
}
