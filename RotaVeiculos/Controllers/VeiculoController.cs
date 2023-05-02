using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RotaVeiculos.Models;
using RotaVeiculos.Repositories.Interfaces;
using RotaVeiculos.Services;
using RotaVeiculos.Services.Interfaces;

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
        public async Task<ActionResult<List<Veiculo>>> BuscarTodosVeiculos()
        {
            List<Veiculo> veiculos = await _veiculoService.BuscarTodosVeiculos();
            return Ok(veiculos);
        }

        [HttpGet("{id}")]
        [Authorize]
        public async Task<ActionResult<Veiculo>> BuscarPorId(int id)
        {
            Veiculo veiculo = await _veiculoService.BuscarPorId(id);
            return Ok(veiculo);
        }

        [HttpPost]
        [Authorize]
        public async Task<ActionResult<Veiculo>> Cadastrar([FromBody] Veiculo veiculoPostRequest)
        {
            Veiculo veiculo = await _veiculoService.Adicionar(veiculoPostRequest);
            return Ok(veiculo);
        }

        [HttpPut("{id}")]
        [Authorize]
        public async Task<ActionResult<Veiculo>> Atualizar(int id, [FromBody] Veiculo veiculoModel)
        {
            veiculoModel.Id = id;
            Veiculo veiculo = await _veiculoService.Atualizar(id, veiculoModel);
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
