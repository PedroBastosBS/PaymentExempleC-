using System;
using Xunit;
using PaymentService.Domain.Factories;

namespace PaymentService.Tests.Domain.Factories
{
    public class UserFactoryTests
    {
        private readonly UserFactory _factory;

        public UserFactoryTests()
        {
            _factory = new UserFactory();
        }

        [Fact]
        public void Create_WithValidData_ShouldReturnUser()
        {
            var email = "test@example.com";
            var passwordHash = "hashed123";

            var user = _factory.Create(email, passwordHash);

            Assert.NotNull(user);
            Assert.Equal(email, user.Email);
            Assert.Equal(passwordHash, user.PasswordHash);
            Assert.Equal("User", user.Role);
            Assert.NotEqual(Guid.Empty, user.Id);
        }

        [Theory]
        [InlineData(null, "hash")]
        [InlineData("   ", "hash")]
        [InlineData("test@example.com", null)]
        [InlineData("test@example.com", "   ")]
        public void Create_WithInvalidData_ShouldThrowArgumentException(string email, string password)
        {
            Assert.Throws<ArgumentException>(() => _factory.Create(email, password));
        }
    }
}
