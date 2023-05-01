using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using RotaVeiculos.Models;
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

        public async Task<Usuario> BuscarPorId(int id)
        {
            var response = await _usuarioRepositorio.BuscarPorId(id);
            return response;
        }

        public async Task<List<Usuario>> BuscarTodosUsuarios()
        {
            var response = await _usuarioRepositorio.BuscarTodosUsuarios();
            return response;
        }

        public async Task<Usuario> Adicionar(Usuario usuario)
        {
            var senhaCriptografada = EncriptarSenha(usuario.Senha);
            usuario.Senha = senhaCriptografada;
            var response = await _usuarioRepositorio.Adicionar(usuario);
            return response;
        }

        public async Task<Usuario> Atualizar(int id, Usuario usuario)
        {
            var senhaCriptografada = EncriptarSenha(usuario.Senha);
            usuario.Senha = senhaCriptografada;
            Usuario usuarioPorId = await BuscarPorId(id);

            if (usuarioPorId != null)
            {
                var response = await _usuarioRepositorio.Atualizar(id, usuario);
                return response;  
            }
            else
            {
                throw new Exception("Usuário não foi encontrado");
            }
        }

        public async Task<bool> Deletar(int id)
        {
            Usuario usuarioPorId = await BuscarPorId(id);

            if (usuarioPorId != null)
            {
                var response = await _usuarioRepositorio.Deletar(id);
                return response;
            }
            else
            {
                throw new Exception("Usuário não foi encontrado");
            }
        }

        public string EncriptarSenha(string senha)
        {
            var passwordHash = BCrypt.Net.BCrypt.HashPassword(senha);
            return passwordHash;
        }

        public bool VerificarSenha(string senha, Usuario usuario)
        {
            bool validarSenha = BCrypt.Net.BCrypt.Verify(senha, usuario.Senha);
            return validarSenha;
        }

        public async Task<ActionResult<dynamic>> Login(string email, string senha)
        {
            var usuario = await _usuarioRepositorio.VerificarLoginValido(email);

            if (VerificarSenha(senha, usuario))
            {
                var token = _tokenService.GenerateToken(usuario);
                usuario.Senha = "";
                return new
                {
                    usuario = usuario,
                    token = token
                };
            }
            else
            {
                throw new Exception("Usuário não encontrado");
            }
        }
    }
}
