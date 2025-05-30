namespace PaymentService.Application.DTOs
{
    public class CreatePlanRequest
    {
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public decimal Price { get; set; }
    }
}