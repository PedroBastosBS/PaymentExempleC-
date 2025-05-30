using PaymentService.Domain.Entities;

namespace PaymentService.Domain.Interfaces
{
    public interface IUserRepository
    {
        Task<User?> GetByEmailAsync(string email);
        Task CreateAsync(User user);
    }
}