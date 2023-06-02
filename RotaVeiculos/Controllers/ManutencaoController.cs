using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RotaVeiculos.Models;
using RotaVeiculos.Repositories.Interfaces;
using RotaVeiculos.Requests.Manutencao;
using RotaVeiculos.Services;
using RotaVeiculos.Services.Interfaces;
using RotaVeiculos.ViewModels.Manutencao;

namespace RotaVeiculos.Controllers
{
    [Route("api/manutencao")]
    [ApiController]
    public class ManutencaoController : ControllerBase
    {
        private readonly IManutencaoService _manutencaoService;

        public ManutencaoController(IManutencaoService manutencaoService)
        {
            _manutencaoService = manutencaoService;
        }

        [HttpGet]
        [Authorize]
        public async Task<ActionResult<List<ManutencaoGridViewModel>>> BuscarTodasManutencoes()
        {
            List<ManutencaoGridViewModel> manutencao = await _manutencaoService.BuscarTodasManutencoes();
            return Ok(manutencao);
        }

        [HttpGet("{id}")]
        [Authorize]
        public async Task<ActionResult<ManutencaoViewModel>> BuscarPorId(int id)
        {
            ManutencaoViewModel manutencao = await _manutencaoService.BuscarPorId(id);
            return Ok(manutencao);
        }

        [HttpPost]
        [Authorize]
        public async Task<ActionResult<ManutencaoViewModel>> Cadastrar([FromBody] ManutencaoRequest manutencaoPostRequest)
        {
            ManutencaoViewModel manutencao = await _manutencaoService.Adicionar(manutencaoPostRequest);
            return Ok(manutencao);
        }

        [HttpPut("{id}")]
        [Authorize]
        public async Task<ActionResult<ManutencaoViewModel>> Atualizar(int id, [FromBody] ManutencaoRequest manutencaoModel)
        {
            ManutencaoViewModel manutencao = await _manutencaoService.Atualizar(id, manutencaoModel);
            return Ok(manutencao);
        }

        [HttpDelete("{id}")]
        [Authorize]
        public async Task<ActionResult<Manutencao>> Deletar(int id)
        {
            bool apagado = await _manutencaoService.Deletar(id);
            return Ok(apagado);
        }
    }
}
