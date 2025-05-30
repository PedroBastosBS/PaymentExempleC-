using PaymentService.Application.DTOs;
using PaymentService.Domain.Factories;
using PaymentService.Domain.Interfaces;

namespace PaymentService.Application.UseCases
{

    public class CreatePlanUseCase : ICreatePlanUseCase
    {

        private readonly IPlanRepository _planRepository;
        private readonly IPlanFactory _planFactory;

        public CreatePlanUseCase(IPlanRepository planRepository, IPlanFactory planFactory)
        {
            _planRepository = planRepository;
            _planFactory = planFactory;
        }

        public async Task<Guid> ExecuteAsync(CreatePlanRequest request)
        {
            var plan = _planFactory.Create(request.Name, request.Price, request.Description);
            await _planRepository.AddAsync(plan);
            return plan.Id;
        }
    }

}