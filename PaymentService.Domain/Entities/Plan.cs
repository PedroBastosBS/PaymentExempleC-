namespace PaymentService.Domain.Entities
{
    public class Plan
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; } = default!;
        public string Description { get; private set; }
        public decimal Price { get; private set; }

        public Plan(string name, decimal price, string description)
        {
            Validate(name, description, price);
            Id = Guid.NewGuid();
            Name = name;
            Price = price;
            Description = description;
        }

        private void Validate(string name, string description, decimal price)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Nome do plano é obrigatório.", nameof(name));

            if (string.IsNullOrWhiteSpace(description))
                throw new ArgumentException("Descrição do plano é obrigatório.", nameof(description));

            if (price < 0)
                throw new ArgumentException("Preço do plano não pode ser negativo.", nameof(price));
        }
    }
}