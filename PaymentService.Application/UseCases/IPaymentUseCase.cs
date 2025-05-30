using PaymentService.Application.DTOs;
using PaymentService.Domain.Entities;

namespace PaymentService.Application.UseCases;

public interface IPaymentUseCase
{
    Payment Execute(Guid UserId, Guid PlanId);
}
