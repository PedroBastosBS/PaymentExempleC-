using PaymentService.Domain.Strategies;
using PaymentService.Domain.Entities;

namespace PaymentService.Application.UseCases
{

    public class PaymentUseCase : IPaymentUseCase
    {

        private readonly IStrategyPayment _strategy;

        public PaymentUseCase(IStrategyPayment strategy)
        {
            _strategy = strategy;
        }

        public Payment Execute(Guid UserId, Guid PlanId)
        {
            return _strategy.Execute(UserId, PlanId);
        }
    }

}