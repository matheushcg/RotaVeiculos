using RotaVeiculos.Models;
using RotaVeiculos.Requests.Usuario;
using RotaVeiculos.ViewModels.Usuario;

namespace RotaVeiculos.Repositories.Interfaces
{
    public interface IUsuarioRepositorio
    {
        Task<List<UsuarioGridViewModel>> BuscarTodosUsuarios();
        Task<UsuarioViewModel> BuscarPorId(int id);
        Task<UsuarioViewModel> Adicionar(UsuarioRequest usuario);
        Task<UsuarioViewModel> Atualizar(int id, UsuarioRequest usuario);
        Task<bool> Deletar(int id);
        Task<Usuario> VerificarLoginValido(string email);
    }
}
