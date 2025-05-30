using PaymentService.Application.DTOs;
using Xunit;

namespace PaymentService.Tests.Application.DTOs
{
    public class CreatePlanRequestTests
    {
        [Fact]
        public void Should_SetAndGetPropertiesCorrectly()
        {
            var dto = new CreatePlanRequest
            {
                Name = "Basic Plan",
                Description = "Descrição do plano básico",
                Price = 49.99m
            };

            Assert.Equal("Basic Plan", dto.Name);
            Assert.Equal("Descrição do plano básico", dto.Description);
            Assert.Equal(49.99m, dto.Price);
        }
    }
}
