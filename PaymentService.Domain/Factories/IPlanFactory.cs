using PaymentService.Domain.Entities;

namespace PaymentService.Domain.Factories
{
    public interface IPlanFactory
    {
        Plan Create(string name, decimal price, string description);
    }
}