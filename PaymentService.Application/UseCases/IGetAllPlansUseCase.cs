using PaymentService.Application.DTOs;

namespace PaymentService.Application.UseCases;

public interface IGetAllPlansUseCase
{
    Task<PaginatedResponse<PlanResponse>> ExecuteAsync(PaginationRequest request);
}
