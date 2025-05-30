using Moq;
using PaymentService.Application.DTOs;
using PaymentService.Application.UseCases;
using PaymentService.Domain.Entities;
using PaymentService.Domain.Factories;
using PaymentService.Domain.Interfaces;
using Xunit;

namespace PaymentService.Tests.Application.UseCases
{
    public class CreatePlanUseCaseTests
    {
        [Fact]
        public async Task ExecuteAsync_ShouldCreatePlanAndReturnId()
        {
            // Arrange
            var request = new CreatePlanRequest
            {
                Name = "Basic Plan",
                Description = "Basic Description",
                Price = 99.99m
            };

            var plan = new Plan(request.Name, request.Price, request.Description);
            var planFactoryMock = new Mock<IPlanFactory>();
            planFactoryMock.Setup(f => f.Create(request.Name, request.Price, request.Description))
                           .Returns(plan);

            var planRepositoryMock = new Mock<IPlanRepository>();
            planRepositoryMock.Setup(r => r.AddAsync(It.IsAny<Plan>()))
                              .Returns(Task.CompletedTask)
                              .Verifiable();

            var useCase = new CreatePlanUseCase(planRepositoryMock.Object, planFactoryMock.Object);

            // Act
            var resultId = await useCase.ExecuteAsync(request);

            // Assert
            Assert.Equal(plan.Id, resultId);
            planRepositoryMock.Verify(r => r.AddAsync(plan), Times.Once);
        }
    }
}
