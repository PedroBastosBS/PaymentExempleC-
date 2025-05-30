namespace PaymentService.Application.DTOs
{
    public class PaymentRequest
    {
        public Guid UserId { get; set; }
        public Guid PaymentId { get; set; }
        public string Description { get; set; }
    }

}