using Microsoft.AspNetCore.Mvc;
using RotaVeiculos.Models;
using RotaVeiculos.Requests.Usuario;
using RotaVeiculos.ViewModels.Usuario;

namespace RotaVeiculos.Services.Interfaces
{
    public interface IUsuarioService
    {
        Task<UsuarioViewModel> BuscarPorId(int id);
        Task<ActionResult<dynamic>> Login(string email, string senha);
        Task<List<UsuarioGridViewModel>> BuscarTodosUsuarios(string nome);
        Task<UsuarioViewModel> Adicionar(UsuarioRequest usuario);
        Task<UsuarioViewModel> Atualizar(int id, UsuarioRequest usuario);
        Task<bool> Deletar(int id);
        string EncriptarSenha(string senha);
        bool VerificarSenha(string senha, Usuario usuario);
    }
}
