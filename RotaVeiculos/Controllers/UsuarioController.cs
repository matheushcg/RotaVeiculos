using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RotaVeiculos.Models;
using RotaVeiculos.Repositories.Interfaces;
using RotaVeiculos.Requests.Login;
using RotaVeiculos.Requests.Usuario;
using RotaVeiculos.Services.Interfaces;
using RotaVeiculos.ViewModels.Usuario;

namespace RotaVeiculos.Controllers
{
    [Route("api/usuario")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioService _usuarioService;

        public UsuarioController(IUsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        [HttpGet]
        [Authorize]
        public async Task<ActionResult<List<UsuarioGridViewModel>>> BuscarTodosUsuarios(string? nome)
        {
            List <UsuarioGridViewModel> usuarios = await _usuarioService.BuscarTodosUsuarios(nome);
            return Ok(usuarios);
        }

        [HttpGet("{id}")]
        [Authorize]
        public async Task<ActionResult<UsuarioViewModel>> BuscarPorId(int id)
        {
            UsuarioViewModel usuario = await _usuarioService.BuscarPorId(id);
            return Ok(usuario);
        }

        [HttpPost]
        [Authorize]
        public async Task<ActionResult<UsuarioViewModel>> Cadastrar([FromBody] UsuarioRequest usuarioPostRequest)
        {
            UsuarioViewModel usuario = await _usuarioService.Adicionar(usuarioPostRequest);
            return Ok(usuario);
        }

        [HttpPost("login")]
        [AllowAnonymous]
        public async Task<ActionResult<dynamic>> Login([FromBody] UsuarioLoginRequest usuarioLoginRequest)
        {
            var response = await _usuarioService.Login(usuarioLoginRequest.Email, usuarioLoginRequest.Senha);

            if(response == null)
            {
                return null;
            }
            else
            {
                return Ok(response);
            }
        }

        [HttpPut("{id}")]
        [Authorize]
        public async Task<ActionResult<UsuarioViewModel>> Atualizar(int id, [FromBody] UsuarioRequest usuarioModel)
        {
            UsuarioViewModel usuario = await _usuarioService.Atualizar(id, usuarioModel);
            return Ok(usuario);
        }

        [HttpDelete("{id}")]
        [Authorize]
        public async Task<ActionResult<Usuario>> Deletar(int id)
        {
            bool apagado = await _usuarioService.Deletar(id);
            return Ok(apagado);
        }
    }
}
