using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RotaVeiculos.Models;
using RotaVeiculos.Services.Interfaces;

namespace RotaVeiculos.Controllers
{
    [Route("api/tipoFinanceiro")]
    [ApiController]
    public class TipoFinanceiroController : ControllerBase
    {
        private readonly ITipoFinanceiroService _tipoFinanceiroService;

        public TipoFinanceiroController(ITipoFinanceiroService tipoFinanceiroService)
        {
            _tipoFinanceiroService = tipoFinanceiroService;
        }

        [HttpGet]
        [Authorize]
        public async Task<ActionResult<List<TipoFinanca>>> BuscarTodosTiposFinancas()
        {
            List<TipoFinanca> tiposFinancas = await _tipoFinanceiroService.BuscarTodosTiposFinancas();
            return Ok(tiposFinancas);
        }

        [HttpGet("{id}")]
        [Authorize]
        public async Task<ActionResult<TipoFinanca>> BuscarPorId(int id)
        {
            TipoFinanca tipoFinanca = await _tipoFinanceiroService.BuscarPorId(id);
            return Ok(tipoFinanca);
        }
    }
}
