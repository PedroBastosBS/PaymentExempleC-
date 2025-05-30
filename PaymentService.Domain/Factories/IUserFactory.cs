using PaymentService.Domain.Entities;

namespace PaymentService.Domain.Factories
{
    public interface IUserFactory
    {
        User Create(string email, string passwordHash);
    }
}