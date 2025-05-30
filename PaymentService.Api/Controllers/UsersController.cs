using Microsoft.AspNetCore.Mvc;
using PaymentService.Application.DTOs;
using PaymentService.Application.UseCases;

namespace PaymentService.Api.Controllers
{
    [ApiController]
    [Route("api/users")]
    [Tags("Rotas de Usuario")]
    public class UsersController : ControllerBase
    {
        private readonly IUserRegistrationUseCase  _userRegistrationUseCase;

        public UsersController(IUserRegistrationUseCase userRegistrationUseCase)
        {
            _userRegistrationUseCase = userRegistrationUseCase;
        }
        /// <summary>
        /// Registra um novo usuário com e-mail e senha.
        /// </summary>
        /// <param name="request">Objeto contendo os dados do usuário a ser registrado.</param>
        /// <returns>Mensagem de sucesso</returns>
        /// <response code="201">Usuário registrado com sucesso</response>
        /// <response code="400">Requisição inválida</response>
        /// <response code="409">Usuário já existente</response>
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] CreateUserRequest request)
        {
            await _userRegistrationUseCase.RegisterAsync(request);
            return Created(string.Empty, new { message = "Usuário registrado com sucesso." });
        }

    }
}