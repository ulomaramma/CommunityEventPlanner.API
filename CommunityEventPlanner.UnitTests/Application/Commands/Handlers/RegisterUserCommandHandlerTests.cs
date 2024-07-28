using CommunityEventPlanner.Application.Interfaces.Services;
using CommunityEventPlanner.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Moq;
using CommunityEventPlanner.Application.UseCases.Users.Command.RegisterUser;
using Microsoft.AspNetCore.Http;
namespace CommunityEventPlanner.UnitTests.Application.Commands.Handlers
{
    public class RegisterUserCommandHandlerTests
    {
        private readonly Mock<UserManager<ApplicationUser>> _userManagerMock;
        private readonly Mock<IAuthService> _authServiceMock;
        private readonly RegisterUserCommandHandler _handler;

        public RegisterUserCommandHandlerTests()
        {
            var userStoreMock = new Mock<IUserStore<ApplicationUser>>();
            _userManagerMock = new Mock<UserManager<ApplicationUser>>(userStoreMock.Object, null, null, null, null, null, null, null, null);
            _authServiceMock = new Mock<IAuthService>();
            _handler = new RegisterUserCommandHandler(_userManagerMock.Object, _authServiceMock.Object);
        }

        [Fact]
        public async Task Handle_ValidRequest_ShouldReturnSuccess()
        {
            // Arrange
            var request = new RegisterUserCommand
            {
                FirstName = "John",
                LastName = "Doe",
                Email = "test.user@everflowutilities.com",
                Password = "Password123!"
            };

            var user = new ApplicationUser
            {
                UserName = request.Email,
                Email = request.Email,
                FirstName = request.FirstName,
                LastName = request.LastName
            };

            _userManagerMock.Setup(x => x.CreateAsync(It.IsAny<ApplicationUser>(), request.Password)).ReturnsAsync(IdentityResult.Success);
            _authServiceMock.Setup(x => x.GenerateJwtToken(It.IsAny<ApplicationUser>())).ReturnsAsync("sample-mocked-jwt-token");

            // Act
            var result = await _handler.Handle(request, CancellationToken.None);

            // Assert
            Assert.True(result.Success);
            Assert.Equal("sample-mocked-jwt-token", result.JwtToken);
            Assert.Equal("User Registered Sucessfully", result.Message);
            Assert.Equal(StatusCodes.Status201Created, result.Code);
        }

        [Fact]
        public async Task Handle_InvalidEmailFormat_ShouldReturnFailure()
        {
            // Arrange
            var request = new RegisterUserCommand
            {
                FirstName = "John",
                LastName = "Doe",
                Email = "test.user@everflowutilities.com",
                Password = "Password123!"
            };

            var user = new ApplicationUser
            {
                UserName = request.Email,
                Email = request.Email,
                FirstName = request.FirstName,
                LastName = request.LastName
            };

            var identityErrors = new IdentityError[]
            {
            new IdentityError { Description = "Invalid email format" }
            };

            _userManagerMock.Setup(x => x.CreateAsync(It.Is<ApplicationUser>(u => u.Email == request.Email), request.Password))
                            .ReturnsAsync(IdentityResult.Failed(identityErrors));

            // Act
            var result = await _handler.Handle(request, CancellationToken.None);

            // Assert
            Assert.False(result.Success);
            Assert.Equal("Invalid email format", result.Message);
            Assert.Equal(StatusCodes.Status400BadRequest, result.Code);
        }
    }
}
