using PaymentService.Domain.Entities;

namespace PaymentService.Domain.Factories
{
    public class PlanFactory : IPlanFactory
    {
        public Plan Create(string name, decimal price, string description)
        {
            return new Plan(name, price, description);
        }
    }
}