using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using RotaVeiculos.Repositories;
using RotaVeiculos.Repositories.Interfaces;
using RotaVeiculos.Services.Interfaces;
using System.Net;

namespace RotaVeiculos.Services
{
    public class UsuarioService : IUsuarioService
    {
        IUsuarioRepositorio _usuarioRepositorio;
        ITokenService _tokenService;

        public UsuarioService(IUsuarioRepositorio usuarioRepositorio, ITokenService tokenService)
        {
            _usuarioRepositorio = usuarioRepositorio;
            _tokenService = tokenService;
        }

        public async Task<ActionResult<dynamic>> Login(string email, string senha)
        {
            var usuario = await _usuarioRepositorio.VerificarLoginValido(email, senha);
            
            var token = _tokenService.GenerateToken(usuario);
            usuario.Senha = "";
            return new
            {
                usuario = usuario,
                token = token
            };
        }
    }
}
