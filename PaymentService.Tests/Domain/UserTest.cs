using Xunit;
using PaymentService.Domain.Entities;

namespace PaymentService.Tests.Domain.Entities
{
    public class UserTests
    {
        [Fact]
        public void Constructor_WithValidParameters_ShouldCreateUser()
        {
            var email = "user@example.com";
            var passwordHash = "hashedPassword";

            var user = new User(email, passwordHash);

            Assert.NotEqual(Guid.Empty, user.Id);
            Assert.Equal(email, user.Email);
            Assert.Equal(passwordHash, user.PasswordHash);
            Assert.Equal("User", user.Role);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("   ")]
        public void Constructor_WithInvalidEmail_ShouldThrowArgumentException(string invalidEmail)
        {
            var passwordHash = "hashedPassword";

            var exception = Assert.Throws<ArgumentException>(() => new User(invalidEmail, passwordHash));
            Assert.Equal("Email é obrigatório. (Parameter 'email')", exception.Message);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("   ")]
        public void Constructor_WithInvalidPassword_ShouldThrowArgumentException(string invalidPassword)
        {
            var email = "user@example.com";

            var exception = Assert.Throws<ArgumentException>(() => new User(email, invalidPassword));
            Assert.Equal("Senha é obrigatório. (Parameter 'passwordHash')", exception.Message);
        }
    }
}