using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RotaVeiculos.Models;
using RotaVeiculos.Repositories.Interfaces;
using RotaVeiculos.Requests.Veiculo;
using RotaVeiculos.Services;
using RotaVeiculos.Services.Interfaces;
using RotaVeiculos.ViewModels.Usuario;
using RotaVeiculos.ViewModels.Veiculo;

namespace RotaVeiculos.Controllers
{
    [Route("api/veiculo")]
    [ApiController]
    public class VeiculoController : ControllerBase
    {
        private readonly IVeiculoService _veiculoService;

        public VeiculoController(IVeiculoService veiculoService)
        {
            _veiculoService = veiculoService;
        }

        [HttpGet]
        [Authorize]
        public async Task<ActionResult<List<VeiculoGridViewModel>>> BuscarTodosVeiculos()
        {
            List<VeiculoGridViewModel> veiculos = await _veiculoService.BuscarTodosVeiculos();
            return Ok(veiculos);
        }

        [HttpGet("{id}")]
        [Authorize]
        public async Task<ActionResult<VeiculoViewModel>> BuscarPorId(int id)
        {
            VeiculoViewModel veiculo = await _veiculoService.BuscarPorId(id);
            return Ok(veiculo);
        }

        [HttpPost]
        [Authorize]
        public async Task<ActionResult<VeiculoViewModel>> Cadastrar([FromBody] VeiculoRequest veiculoPostRequest)
        {
            VeiculoViewModel veiculo = await _veiculoService.Adicionar(veiculoPostRequest);
            return Ok(veiculo);
        }

        [HttpPut("{id}")]
        [Authorize]
        public async Task<ActionResult<VeiculoViewModel>> Atualizar(int id, [FromBody] VeiculoRequest veiculoModel)
        {
            VeiculoViewModel veiculo = await _veiculoService.Atualizar(id, veiculoModel);
            return Ok(veiculo);
        }

        [HttpDelete("{id}")]
        [Authorize]
        public async Task<ActionResult<Veiculo>> Deletar(int id)
        {
            bool apagado = await _veiculoService.Deletar(id);
            return Ok(apagado);
        }
    }
}
