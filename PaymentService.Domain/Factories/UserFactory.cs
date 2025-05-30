using PaymentService.Domain.Entities;

namespace PaymentService.Domain.Factories
{
    public class UserFactory : IUserFactory
    {
        public User Create(string email, string passwordHash)
        {
            return new User(email, passwordHash);
        }
    }
}