using Microsoft.EntityFrameworkCore;
using PaymentService.Domain.Entities;
using PaymentService.Domain.Interfaces;
using PaymentService.Infrastructure.Persistence;

namespace PaymentService.Infrastructure.Repositories
{
    public class PlanRepository : IPlanRepository
    {
        private readonly PaymentDbContext _context;

        public PlanRepository(PaymentDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Plan plan)
        {
            await _context.Plans.AddAsync(plan);
            await _context.SaveChangesAsync();
        }

        public async Task<(IEnumerable<Plan>, int)> GetPaginatedAsync(int page, int pageSize)
        {
            var totalItems = await _context.Plans.CountAsync();

            var plans = await _context.Plans
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            return (plans, totalItems);
        }

    }
}
