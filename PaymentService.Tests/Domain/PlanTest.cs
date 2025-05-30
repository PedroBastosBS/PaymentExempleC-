using PaymentService.Domain.Entities;
using Xunit;

namespace PaymentService.Tests.Domain.Entities
{
    public class PlanTests
    {
        [Fact(DisplayName = "Dado um plano válido, quando criado, então os campos devem ser atribuídos corretamente")]
        public void CriarPlano_Valido_DeveCriarCorretamente()
        {
            var name = "Plano Premium";
            var description = "Acesso ilimitado aos recursos";
            var price = 99.90m;

            var plan = new Plan(name, price, description);

            Assert.Equal(name, plan.Name);
            Assert.Equal(description, plan.Description);
            Assert.Equal(price, plan.Price);
            Assert.NotEqual(Guid.Empty, plan.Id);
        }

        [Theory(DisplayName = "Dado nome inválido, quando criar plano, então deve lançar exceção")]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("   ")]
        public void CriarPlano_NomeInvalido_DeveLancarExcecao(string nomeInvalido)
        {
            var description = "Descrição válida";
            var price = 50;

            var ex = Assert.Throws<ArgumentException>(() => new Plan(nomeInvalido, price, description));
            Assert.Equal("name", ex.ParamName);
        }

        [Theory(DisplayName = "Dado descrição inválida, quando criar plano, então deve lançar exceção")]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("   ")]
        public void CriarPlano_DescricaoInvalida_DeveLancarExcecao(string descricaoInvalida)
        {
            var name = "Plano Teste";
            var price = 50;

            var ex = Assert.Throws<ArgumentException>(() => new Plan(name, price, descricaoInvalida));
            Assert.Equal("description", ex.ParamName);
        }

        [Fact(DisplayName = "Dado preço negativo, quando criar plano, então deve lançar exceção")]
        public void CriarPlano_PrecoNegativo_DeveLancarExcecao()
        {
            var name = "Plano Teste";
            var description = "Descrição válida";
            var price = -10;

            var ex = Assert.Throws<ArgumentException>(() => new Plan(name, price, description));
            Assert.Equal("price", ex.ParamName);
        }
    }
}
