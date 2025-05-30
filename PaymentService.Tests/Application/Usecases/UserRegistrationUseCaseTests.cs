using Moq;
using Xunit;
using PaymentService.Application.UseCases;
using PaymentService.Domain.Entities;
using PaymentService.Domain.Factories;
using PaymentService.Domain.Interfaces;
using PaymentService.Application.DTOs;

namespace PaymentService.Tests.Application.UseCases
{
    public class UserRegistrationUseCaseTests
    {
        private readonly Mock<IUserRepository> _userRepositoryMock;
        private readonly Mock<IUserFactory> _userFactoryMock;
        private readonly UserRegistrationUseCase _registrationService;

        public UserRegistrationUseCaseTests()
        {
            _userRepositoryMock = new Mock<IUserRepository>();
            _userFactoryMock = new Mock<IUserFactory>();
            _registrationService = new UserRegistrationUseCase(_userRepositoryMock.Object, _userFactoryMock.Object);
        }

        [Fact]
        public async Task RegisterAsync_WithNewEmail_ShouldCreateUser()
        {
            
            var request = new CreateUserRequest
            {
                Email = "newuser@example.com",
                Password = "plainPassword"
            };

            _userRepositoryMock
                .Setup(repo => repo.GetByEmailAsync(request.Email))
                .ReturnsAsync((User)null!);

            var expectedUser = new User(request.Email, "hashedPassword");

            _userFactoryMock
                .Setup(factory => factory.Create(request.Email, It.IsAny<string>()))
                .Returns(expectedUser);

            await _registrationService.RegisterAsync(request);

            _userRepositoryMock.Verify(repo => repo.CreateAsync(It.Is<User>(u => u.Email == request.Email)), Times.Once);
        }

        [Fact]
        public async Task RegisterAsync_WithExistingEmail_ShouldThrowException()
        {
            var request = new CreateUserRequest
            {
                Email = "existing@example.com",
                Password = "irrelevantPassword"
            };

            var existingUser = new User(request.Email, "alreadyHashed");

            _userRepositoryMock
                .Setup(repo => repo.GetByEmailAsync(request.Email))
                .ReturnsAsync(existingUser);

            var ex = await Assert.ThrowsAsync<Exception>(() => _registrationService.RegisterAsync(request));
            Assert.Equal("Usuario já está cadastrado", ex.Message);

            _userRepositoryMock.Verify(repo => repo.CreateAsync(It.IsAny<User>()), Times.Never);
        }
    }
}
