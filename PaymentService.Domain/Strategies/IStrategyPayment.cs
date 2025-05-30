using PaymentService.Domain.Entities;

namespace PaymentService.Domain.Strategies
{
    public interface IStrategyPayment
    {
        Payment Execute(Guid userId, Guid planId);
    }
}