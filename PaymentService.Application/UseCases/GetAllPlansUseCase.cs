using PaymentService.Application.DTOs;
using PaymentService.Domain.Interfaces;

namespace PaymentService.Application.UseCases;

public class GetAllPlansUseCase : IGetAllPlansUseCase
{
    private readonly IPlanRepository _planRepository;

    public GetAllPlansUseCase(IPlanRepository planRepository)
    {
        _planRepository = planRepository;
    }

    public async Task<PaginatedResponse<PlanResponse>> ExecuteAsync(PaginationRequest request)
    {
        var (plans, totalCount) = await _planRepository.GetPaginatedAsync(request.Page, request.PageSize);

        return new PaginatedResponse<PlanResponse>
        {
            Items = plans.Select(p => new PlanResponse
            {
                Id = p.Id,
                Name = p.Name,
                Description = p.Description,
                Price = p.Price
            }),
            TotalItems = totalCount,
            Page = request.Page,
            PageSize = request.PageSize
        };
    }
}
