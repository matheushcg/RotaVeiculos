using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RotaVeiculos.Models;
using RotaVeiculos.Repositories.Interfaces;
using RotaVeiculos.Requests;
using RotaVeiculos.Services.Interfaces;

namespace RotaVeiculos.Controllers
{
    [Route("api/usuario")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioService _usuarioService;

        public UsuarioController(IUsuarioRepositorio usuarioRepositorio, IUsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        [HttpGet]
        [Authorize]
        public async Task<ActionResult<List<Usuario>>> BuscarTodosUsuarios()
        {
            List <Usuario> usuarios = await _usuarioService.BuscarTodosUsuarios();
            return Ok(usuarios);
        }

        [HttpGet("{id}")]
        [Authorize]
        public async Task<ActionResult<Usuario>> BuscarPorId(int id)
        {
            Usuario usuario = await _usuarioService.BuscarPorId(id);
            return Ok(usuario);
        }

        [HttpPost]
        [Authorize]
        public async Task<ActionResult<Usuario>> Cadastrar([FromBody] Usuario usuarioPostRequest)
        {
            Usuario usuario = await _usuarioService.Adicionar(usuarioPostRequest);
            return Ok(usuario);
        }

        [HttpPost("login")]
        [AllowAnonymous]
        public async Task<ActionResult<dynamic>> Login([FromBody] UsuarioLoginRequest usuarioLoginRequest)
        {
            var response = await _usuarioService.Login(usuarioLoginRequest.Email, usuarioLoginRequest.Senha);

            if(response == null)
            {
                return NotFound(new {message = "Email ou Senha inválidos"});
            }
            else
            {
                return Ok(response);
            }
        }

        [HttpPut("{id}")]
        [Authorize]
        public async Task<ActionResult<Usuario>> Atualizar(int id, [FromBody] Usuario usuarioModel)
        {
            usuarioModel.Id = id;
            Usuario usuario = await _usuarioService.Atualizar(id, usuarioModel);
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
