using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RotaVeiculos.Models;
using RotaVeiculos.Repositories.Interfaces;

namespace RotaVeiculos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioRepositorio _usuarioRepositorio;

        public UsuarioController(IUsuarioRepositorio usuarioRepositorio)
        {
            _usuarioRepositorio = usuarioRepositorio;
        }

        [HttpGet]
        public async Task<ActionResult<List<Usuario>>> BuscarTodosUsuarios()
        {
            List <Usuario> usuarios = await _usuarioRepositorio.BuscarTodosUsuarios();
            return Ok(usuarios);
        }

        [HttpGet("buscarPorId/{id}")]
        public async Task<ActionResult<Usuario>> BuscarPorId(int id)
        {
            Usuario usuario = await _usuarioRepositorio.BuscarPorId(id);
            return Ok(usuario);
        }

        [HttpPost]
        public async Task<ActionResult<Usuario>> Cadastrar([FromBody] Usuario usuarioModel)
        {
            Usuario usuario = await _usuarioRepositorio.Adicionar(usuarioModel);
            return Ok(usuario);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Usuario>> Atualizar(int id, [FromBody] Usuario usuarioModel)
        {
            usuarioModel.Id = id;
            Usuario usuario = await _usuarioRepositorio.Atualizar(id, usuarioModel);
            return Ok(usuario);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Usuario>> Deletar(int id)
        {
            bool apagado = await _usuarioRepositorio.Deletar(id);
            return Ok(apagado);
        }
    }
}
