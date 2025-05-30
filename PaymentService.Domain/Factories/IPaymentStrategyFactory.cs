using PaymentService.Domain.Entities;
using PaymentService.Domain.Strategies;

namespace PaymentService.Domain.Factories
{
    public interface IPaymentStrategyFactory
    {
        IStrategyPayment GetStrategy(string paymentMethod);
    }
}