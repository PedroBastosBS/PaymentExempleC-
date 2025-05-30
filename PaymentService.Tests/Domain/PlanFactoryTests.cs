using PaymentService.Domain.Factories;
using Xunit;

namespace PaymentService.Tests.Domain.Factories
{
    public class PlanFactoryTests
    {
        private readonly PlanFactory _factory;

        public PlanFactoryTests()
        {
            _factory = new PlanFactory();
        }

        [Fact]
        public void Create_ShouldReturnPlan_WithCorrectProperties()
        {
            
            var name = "Premium";
            var price = 199.99m;
            var description = "Plano Premium";

            var plan = _factory.Create(name, price, description);

            Assert.NotNull(plan);
            Assert.Equal(name, plan.Name);
            Assert.Equal(price, plan.Price);
            Assert.Equal(description, plan.Description);
            Assert.NotEqual(Guid.Empty, plan.Id);
        }
    }
}
