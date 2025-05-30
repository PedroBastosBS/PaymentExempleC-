namespace PaymentService.Domain.Entities
{
    public class User
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Email { get; set; } = string.Empty;
        public string PasswordHash { get; set; } = string.Empty;
        public string Role { get; set; } = "User";

        public User(string email, string passwordHash)
        {
            Validate(email, passwordHash);
            Id = Guid.NewGuid();
            Email = email;
            PasswordHash = passwordHash;
        }

         private void Validate(string email, string passwordHash)
        {
            if (string.IsNullOrWhiteSpace(email))
                throw new ArgumentException("Email é obrigatório.", nameof(email));

            if (string.IsNullOrWhiteSpace(passwordHash))
                throw new ArgumentException("Senha é obrigatório.", nameof(passwordHash));
        }
    }
}