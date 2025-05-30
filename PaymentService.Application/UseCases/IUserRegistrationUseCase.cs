
using PaymentService.Application.DTOs;

namespace PaymentService.Application.UseCases
{
    public interface IUserRegistrationUseCase
    {
        Task RegisterAsync(CreateUserRequest request);
    }
}