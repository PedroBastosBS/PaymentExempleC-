using System;
using Xunit;
using PaymentService.Application.DTOs;

namespace PaymentService.Tests.DTOs
{
    public class PlanResponseTests
    {
        [Fact]
        public void Properties_ShouldStoreAndReturnCorrectValues()
        {
            var id = Guid.NewGuid();
            var name = "Plano Premium";
            var description = "Acesso completo a todos os recursos";
            var price = 99.90m;

            var response = new PlanResponse
            {
                Id = id,
                Name = name,
                Description = description,
                Price = price
            };

            Assert.Equal(id, response.Id);
            Assert.Equal(name, response.Name);
            Assert.Equal(description, response.Description);
            Assert.Equal(price, response.Price);
        }
    }
}
