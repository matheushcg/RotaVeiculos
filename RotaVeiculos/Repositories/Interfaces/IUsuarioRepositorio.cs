using RotaVeiculos.Models;

namespace RotaVeiculos.Repositories.Interfaces
{
    public interface IUsuarioRepositorio
    {
        Task<List<Usuario>> BuscarTodosUsuarios();
        Task<Usuario> BuscarPorId(int id);
        Task<Usuario> Adicionar(Usuario usuario);
        Task<Usuario> Atualizar(int id, Usuario usuario);
        Task<bool> Deletar(int id);
    }
}
