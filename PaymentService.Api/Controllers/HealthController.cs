using Microsoft.AspNetCore.Mvc;

namespace PaymentService.Api.Controllers
{
    [ApiController]
    [Route("api/health")]
    [Tags("Gerenciamento da saude da Aplicação")]
    public class HealthController : ControllerBase
    {
        /// <summary>
        /// Verifica o status da API.
        /// </summary>
        [HttpGet]
        public IActionResult GetHealth() => Ok(new { status = "Healthy", timestamp = DateTime.UtcNow });
    }
}

