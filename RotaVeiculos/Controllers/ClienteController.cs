using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RotaVeiculos.Models;
using RotaVeiculos.Requests.Cliente;
using RotaVeiculos.Requests.Financa;
using RotaVeiculos.Services;
using RotaVeiculos.Services.Interfaces;
using RotaVeiculos.ViewModels.Cliente;
using RotaVeiculos.ViewModels.Financa;

namespace RotaVeiculos.Controllers
{
    [Route("api/cliente")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private readonly IClienteService _clienteService;

        public ClienteController(IClienteService clienteService)
        {
            _clienteService = clienteService;
        }

        [HttpGet]
        [Authorize]
        public async Task<ActionResult<List<ClienteGridViewModel>>> BuscarTodosClientes(string? nome)
        {
            List<ClienteGridViewModel> clientes = await _clienteService.BuscarTodosClientes(nome);
            return Ok(clientes);
        }

        [HttpGet("{id}")]
        [Authorize]
        public async Task<ActionResult<ClienteViewModel>> BuscarPorId(int id)
        {
            ClienteViewModel cliente = await _clienteService.BuscarPorId(id);
            return Ok(cliente);
        }

        [HttpPost]
        [Authorize]
        public async Task<ActionResult<ClienteViewModel>> Cadastrar([FromBody] ClienteRequest clientePostRequest)
        {
            ClienteViewModel cliente = await _clienteService.Adicionar(clientePostRequest);
            return Ok(cliente);
        }

        [HttpPut("{id}")]
        [Authorize]
        public async Task<ActionResult<ClienteViewModel>> Atualizar(int id, [FromBody] ClienteRequest clienteModel)
        {
            ClienteViewModel cliente = await _clienteService.Atualizar(id, clienteModel);
            return Ok(cliente);
        }

        [HttpDelete("{id}")]
        [Authorize]
        public async Task<ActionResult<Cliente>> Deletar(int id)
        {
            bool apagado = await _clienteService.Deletar(id);
            return Ok(apagado);
        }
    }
}
