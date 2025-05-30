using Microsoft.AspNetCore.Mvc;
using PaymentService.Application.DTOs;
using PaymentService.Application.UseCases;

namespace PaymentService.Api.Controllers
{
    [ApiController]
    [Route("api/plans")]
    [Tags("Rotas de planos")]
    public class PlansController : ControllerBase
    {
        private readonly ICreatePlanUseCase _createPlanUseCase;

        private readonly IGetAllPlansUseCase _getAllPlansUseCase;

        public PlansController(ICreatePlanUseCase createPlanUseCase, IGetAllPlansUseCase getAllPlansUseCase)
        {
            _createPlanUseCase = createPlanUseCase;
            _getAllPlansUseCase = getAllPlansUseCase;
        }

        /// <summary>
        /// Cria um novo plano com nome, descrição e preço.
        /// </summary>
        /// <param name="request">Objeto com os dados do plano a ser criado</param>
        /// <returns>O ID do plano criado</returns>
        /// <response code="201">Plano criado com sucesso</response>
        [HttpPost]
        [Tags("Criação de Planos")]
        public async Task<IActionResult> Create([FromBody] CreatePlanRequest request)
        {
            var result = await _createPlanUseCase.ExecuteAsync(request);
            return Created(string.Empty, result);
        }

        /// <summary>
        /// Lista todos os planos de forma paginada.
        /// </summary>
        /// <param name="page">Número da página (padrão 1)</param>
        /// <param name="pageSize">Quantidade de itens por página (padrão 10)</param>
        /// <returns>Lista paginada dos planos</returns>
        [HttpGet]
        [Tags("Listagem de Planos")]
        public async Task<IActionResult> GetAll([FromQuery] PaginationRequest request)
        {
            var result = await _getAllPlansUseCase.ExecuteAsync(request);
            return Ok(result);
        }
    }
}