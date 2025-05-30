using System.Security.Cryptography;
using System.Text;
using PaymentService.Application.DTOs;
using PaymentService.Domain.Entities;
using PaymentService.Domain.Factories;
using PaymentService.Domain.Interfaces;

namespace PaymentService.Application.UseCases
{
    public class UserRegistrationUseCase : IUserRegistrationUseCase
    {
        private readonly IUserRepository _userRepository;
        private readonly IUserFactory _userFactory;
        public UserRegistrationUseCase(IUserRepository userRepository, IUserFactory userFactory)
        {
            _userRepository = userRepository;
            _userFactory = userFactory;
        }

        public async Task RegisterAsync(CreateUserRequest request)
        {
            var existing = await _userRepository.GetByEmailAsync(request.Email);
            if (existing != null)
                throw new Exception("Usuario já está cadastrado");
            var passwordHash = HashPassword(request.Password);
            var user = _userFactory.Create(request.Email, passwordHash);
            await _userRepository.CreateAsync(user);
        }

        private string HashPassword(string password)
        {
            using var sha256 = SHA256.Create();
            var bytes = Encoding.UTF8.GetBytes(password);
            var hash = sha256.ComputeHash(bytes);
            return Convert.ToBase64String(hash);
        }
    }
}