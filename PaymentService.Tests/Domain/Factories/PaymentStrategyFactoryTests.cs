using Xunit;
using System.Collections.Generic;
using PaymentService.Domain.Factories;
using PaymentService.Domain.Strategies;
public class PaymentStrategyFactoryTests
{
    [Fact]
    public void GetStrategy_ReturnsCorrectStrategy_WhenPaymentMethodExists()
    {
        var strategies = new List<IStrategyPayment>
        {
            new CreditCardStrategy(),
            new PixStrategy(),
            new TicketStrategy()
        };

        var factory = new PaymentStrategyFactory(strategies);

        var strategy = factory.GetStrategy("creditcard");

        Assert.IsType<CreditCardStrategy>(strategy);
    }
}
