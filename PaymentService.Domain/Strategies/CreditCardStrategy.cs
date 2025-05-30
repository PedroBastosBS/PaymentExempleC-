using PaymentService.Domain.Entities;
using System;

namespace PaymentService.Domain.Strategies
{
    public class CreditCardStrategy : IStrategyPayment
    {
        public Payment Execute(Guid userId, Guid planId)
        {
            return new Payment(userId, planId, "Cartão de credito");
        }
    }
}
