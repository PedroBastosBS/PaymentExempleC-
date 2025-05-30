using System;
using Moq;
using PaymentService.Application.UseCases;
using PaymentService.Domain.Entities;
using PaymentService.Domain.Strategies;
using Xunit;

namespace PaymentService.Tests.Application.UseCases
{
    public class PaymentUseCaseTests
    {
        [Fact]
        public void Execute_DeveChamarStrategyERegredirPagamento()
        {
            var userId = Guid.NewGuid();
            var planId = Guid.NewGuid();

            var paymentEsperado = new Payment(userId, planId, "boleto");

            var strategyMock = new Mock<IStrategyPayment>();
            strategyMock
                .Setup(s => s.Execute(userId, planId))
                .Returns(paymentEsperado);

            var useCase = new PaymentUseCase(strategyMock.Object);

            var resultado = useCase.Execute(userId, planId);

            strategyMock.Verify(s => s.Execute(userId, planId), Times.Once);
            Assert.Equal(paymentEsperado, resultado);
        }
    }
}
