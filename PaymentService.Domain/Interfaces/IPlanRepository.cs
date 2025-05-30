using PaymentService.Domain.Entities;

namespace PaymentService.Domain.Interfaces
{
    public interface IPlanRepository
    {
        Task AddAsync(Plan plan);
        Task<(IEnumerable<Plan> Plans, int TotalCount)> GetPaginatedAsync(int page, int pageSize);
    }
}