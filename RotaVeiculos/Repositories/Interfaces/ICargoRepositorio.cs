using RotaVeiculos.Models;

namespace RotaVeiculos.Repositories.Interfaces
{
    public interface ICargoRepositorio
    {
        Task<List<Cargo>> BuscarTodosCargos();
        Task<Cargo> BuscarPorId(int id);
    }
}