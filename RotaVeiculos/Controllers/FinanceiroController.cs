using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RotaVeiculos.Models;
using RotaVeiculos.Requests.Financa;
using RotaVeiculos.Requests.Veiculo;
using RotaVeiculos.Services.Interfaces;
using RotaVeiculos.ViewModels.Financa;
using RotaVeiculos.ViewModels.Veiculo;

namespace RotaVeiculos.Controllers
{
    [Route("api/financeiro")]
    [ApiController]
    public class FinanceiroController : ControllerBase
    {
        private readonly IFinanceiroService _financeiroService;

        public FinanceiroController(IFinanceiroService financeiroService)
        {
            _financeiroService = financeiroService;
        }

        [HttpGet]
        [Authorize]
        public async Task<ActionResult<List<FinancaGridViewModel>>> BuscarTodasFinancas()
        {
            List<FinancaGridViewModel> financas = await _financeiroService.BuscarTodasFinancas();
            return Ok(financas);
        }

        [HttpGet("{id}")]
        [Authorize]
        public async Task<ActionResult<FinancaViewModel>> BuscarPorId(int id)
        {
            FinancaViewModel financa = await _financeiroService.BuscarPorId(id);
            return Ok(financa);
        }

        [HttpPost]
        [Authorize]
        public async Task<ActionResult<FinancaViewModel>> Cadastrar([FromBody] FinancaRequest financaPostRequest)
        {
            FinancaViewModel financa = await _financeiroService.Adicionar(financaPostRequest);
            return Ok(financa);
        }

        [HttpPut("{id}")]
        [Authorize]
        public async Task<ActionResult<FinancaViewModel>> Atualizar(int id, [FromBody] FinancaRequest financaModel)
        {
            FinancaViewModel financa = await _financeiroService.Atualizar(id, financaModel);
            return Ok(financa);
        }

        [HttpDelete("{id}")]
        [Authorize]
        public async Task<ActionResult<Financa>> Deletar(int id)
        {
            bool apagado = await _financeiroService.Deletar(id);
            return Ok(apagado);
        }
    }
}
