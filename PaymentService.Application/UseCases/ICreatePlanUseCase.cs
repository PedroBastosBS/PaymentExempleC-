using PaymentService.Application.DTOs;

namespace PaymentService.Application.UseCases
{
    public interface ICreatePlanUseCase
    {
        Task<Guid> ExecuteAsync(CreatePlanRequest request);
    }
}