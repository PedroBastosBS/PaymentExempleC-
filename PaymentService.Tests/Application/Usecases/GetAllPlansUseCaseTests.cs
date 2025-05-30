using Xunit;
using Moq;
using PaymentService.Application.DTOs;
using PaymentService.Application.UseCases;
using PaymentService.Domain.Entities;
using PaymentService.Domain.Interfaces;

namespace PaymentService.Tests.UseCases
{
    public class GetAllPlansUseCaseTests
    {
        [Fact]
        public async Task ExecuteAsync_ReturnsPaginatedResponse()
        {
            var mockRepository = new Mock<IPlanRepository>();
            var plans = new List<Plan>
            {
                new Plan("Plano 1", 10.0m, "Desc 1"),
                new Plan("Plano 2", 20.0m, "Desc 2")
            };

            int totalCount = 2;
            int page = 1;
            int pageSize = 10;

            mockRepository
                .Setup(repo => repo.GetPaginatedAsync(page, pageSize))
                .ReturnsAsync((plans, totalCount));

            var useCase = new GetAllPlansUseCase(mockRepository.Object);
            var request = new PaginationRequest { Page = page, PageSize = pageSize };

            var result = await useCase.ExecuteAsync(request);

            Assert.NotNull(result);
            Assert.Equal(totalCount, result.TotalItems);
            Assert.Equal(page, result.Page);
            Assert.Equal(pageSize, result.PageSize);
            Assert.Equal(plans.Count, result.Items.Count());
            Assert.Contains(result.Items, r => r.Name == "Plano 1");
            Assert.Contains(result.Items, r => r.Name == "Plano 2");
        }
    }
}
