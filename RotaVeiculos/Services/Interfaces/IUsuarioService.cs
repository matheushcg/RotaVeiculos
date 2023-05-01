using Microsoft.AspNetCore.Mvc;
using RotaVeiculos.Models;

namespace RotaVeiculos.Services.Interfaces
{
    public interface IUsuarioService
    {
        Task<Usuario> BuscarPorId(int id);
        Task<ActionResult<dynamic>> Login(string email, string senha);
        Task<List<Usuario>> BuscarTodosUsuarios();
        Task<Usuario> Adicionar(Usuario usuario);
        Task<Usuario> Atualizar(int id, Usuario usuario);
        Task<bool> Deletar(int id);
        string EncriptarSenha(string senha);
        bool VerificarSenha(string senha, Usuario usuario);
    }
}
