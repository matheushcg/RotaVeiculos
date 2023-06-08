using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using RotaVeiculos.Models;
using RotaVeiculos.Repositories;
using RotaVeiculos.Repositories.Interfaces;
using RotaVeiculos.Requests.Usuario;
using RotaVeiculos.Services.Interfaces;
using RotaVeiculos.ViewModels.Usuario;
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

        public async Task<UsuarioViewModel> BuscarPorId(int id)
        {
            var response = await _usuarioRepositorio.BuscarPorId(id);
            return response;
        }

        public async Task<List<UsuarioGridViewModel>> BuscarTodosUsuarios(string nome)
        {
            var response = await _usuarioRepositorio.BuscarTodosUsuarios(nome);
            return response;
        }

        public async Task<UsuarioViewModel> Adicionar(UsuarioRequest usuario)
        {
            var senhaCriptografada = EncriptarSenha(usuario.Senha);
            usuario.Senha = senhaCriptografada;
            var response = await _usuarioRepositorio.Adicionar(usuario);
            return response;
        }

        public async Task<UsuarioViewModel> Atualizar(int id, UsuarioRequest usuario)
        {
            var senhaCriptografada = EncriptarSenha(usuario.Senha);
            usuario.Senha = senhaCriptografada;
            var usuarioViewModel = await BuscarPorId(id);
            Usuario usuarioPorId = new Usuario(usuarioViewModel.Id, usuarioViewModel.Email, usuarioViewModel.Nome, usuarioViewModel.Senha, usuarioViewModel.Cpf, usuarioViewModel.Telefone, usuarioViewModel.CargoId);

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
            var usuarioViewModel = await BuscarPorId(id);
            Usuario usuarioPorId = new Usuario(usuarioViewModel.Id, usuarioViewModel.Email, usuarioViewModel.Nome, usuarioViewModel.Senha, usuarioViewModel.Cpf, usuarioViewModel.Telefone, usuarioViewModel.CargoId);

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
