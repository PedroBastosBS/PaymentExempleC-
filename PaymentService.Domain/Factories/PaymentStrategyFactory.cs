using PaymentService.Domain.Entities;
using PaymentService.Domain.Strategies;

namespace PaymentService.Domain.Factories
{
    public class PaymentStrategyFactory : IPaymentStrategyFactory
    {
        private readonly IDictionary<string, IStrategyPayment> _strategies;
        public PaymentStrategyFactory(IEnumerable<IStrategyPayment> strategies)
        {
            _strategies = strategies.ToDictionary(
                s => s.GetType().Name.Replace("Strategy", "").ToLower(),
                s => s
            );
        }
        public IStrategyPayment GetStrategy(string paymentMethod)
        {
            if (string.IsNullOrWhiteSpace(paymentMethod))
                throw new ArgumentNullException(nameof(paymentMethod));

            paymentMethod = paymentMethod.ToLower();

            if (_strategies.ContainsKey(paymentMethod))
                return _strategies[paymentMethod];

            throw new ArgumentException($"Método de pagamento '{paymentMethod}' não suportado.");
        }
    }
}