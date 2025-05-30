namespace PaymentService.Domain.Entities
{
    public class Payment
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public Guid UserId { get; set; }
        public Guid PlanId { get; set; }
        public string PaymentMethod { get; set; } = "";

        public Payment(Guid userId, Guid planId, string paymentMethod)
        {
            Validate(userId, planId, paymentMethod);
            Id = Guid.NewGuid();
            UserId = userId;
            PlanId = planId;
            PaymentMethod = paymentMethod;
        }
        
        private void Validate(Guid userId, Guid planId, string PaymentMethod)
        {
            if (userId == Guid.Empty)
                throw new ArgumentException("É necessario informar o usuario.", nameof(userId));

            if (planId == Guid.Empty)
                throw new ArgumentException("É necessario informar o plano", nameof(planId));

            if (string.IsNullOrWhiteSpace(PaymentMethod))
                throw new ArgumentException("Metodo de pagamento é obrigatório.", nameof(PaymentMethod));
        }
    }
}