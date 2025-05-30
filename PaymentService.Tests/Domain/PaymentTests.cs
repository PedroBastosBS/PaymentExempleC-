using System;
using PaymentService.Domain.Entities;
using Xunit;

namespace PaymentService.Tests.Entities
{
    public class PaymentTests
    {
        [Fact]
        public void CriarPagamento_Valido_DeveCriarComSucesso()
        {
            var userId = Guid.NewGuid();
            var planId = Guid.NewGuid();
            var paymentMethod = "Boleto";

            var payment = new Payment(userId, planId, paymentMethod);

            Assert.NotEqual(Guid.Empty, payment.Id);
            Assert.Equal(userId, payment.UserId);
            Assert.Equal(planId, payment.PlanId);
            Assert.Equal(paymentMethod, payment.PaymentMethod);
        }

        [Fact]
        public void CriarPagamento_ComUserIdVazio_DeveLancarArgumentException()
        {
            var userId = Guid.Empty;
            var planId = Guid.NewGuid();
            var paymentMethod = "Cartao";

            var ex = Assert.Throws<ArgumentException>(() => new Payment(userId, planId, paymentMethod));
            Assert.Contains("É necessario informar o usuario.", ex.Message);
        }

        [Fact]
        public void CriarPagamento_ComPlanIdVazio_DeveLancarArgumentException()
        {
            var userId = Guid.NewGuid();
            var planId = Guid.Empty;
            var paymentMethod = "Pix";

            var ex = Assert.Throws<ArgumentException>(() => new Payment(userId, planId, paymentMethod));
            Assert.Contains("É necessario informar o plano", ex.Message);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("   ")]
        public void CriarPagamento_ComPaymentMethodInvalido_DeveLancarArgumentException(string invalidPaymentMethod)
        {
            var userId = Guid.NewGuid();
            var planId = Guid.NewGuid();

            var ex = Assert.Throws<ArgumentException>(() => new Payment(userId, planId, invalidPaymentMethod));
            Assert.Contains("Metodo de pagamento é obrigatório.", ex.Message);
        }
    }
}
