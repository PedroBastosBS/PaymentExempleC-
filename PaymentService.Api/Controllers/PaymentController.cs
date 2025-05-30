using Microsoft.AspNetCore.Mvc;
using PaymentService.Domain.Factories;
using PaymentService.Domain.Entities;
using PaymentService.Application.DTOs;
using System;

namespace PaymentService.Api.Controllers
{
    [ApiController]
    [Route("api/payments")]
    [Tags("Gerenciamento de pagamentos")]
    public class PaymentController : ControllerBase
    {
        private readonly IPaymentStrategyFactory _paymentStrategyFactory;

        public PaymentController(IPaymentStrategyFactory paymentStrategyFactory)
        {
            _paymentStrategyFactory = paymentStrategyFactory ?? throw new ArgumentNullException(nameof(paymentStrategyFactory));
        }

        /// <summary>
        /// Processa um pagamento baseado no método informado.
        /// </summary>
        /// <param name="paymentMethod">Método de pagamento, ex: "ticket", "pix", "creditcard"</param>
        /// <param name="paymentRequest">Dados do pagamento (exemplo simplificado)</param>
        [HttpPost("{paymentMethod}")]
        public IActionResult ProcessPayment(string paymentMethod, [FromBody] PaymentRequest paymentRequest)
        {
            if (string.IsNullOrWhiteSpace(paymentMethod))
                return BadRequest("O método de pagamento é obrigatório.");

            try
            {
                var strategy = _paymentStrategyFactory.GetStrategy(paymentMethod);
                return Ok(new { message = $"Pagamento via {paymentMethod} processado com sucesso." });
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { error = ex.Message });
            }
            catch (Exception)
            {
                return StatusCode(500, "Erro interno ao processar pagamento.");
            }
        }
    }
}
