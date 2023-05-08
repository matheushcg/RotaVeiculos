using RotaVeiculos.Models;

namespace RotaVeiculos.Services.Interfaces
{
    public interface ICargoService
    {
        Task<List<Cargo>> BuscarTodosCargos();
        Task<Cargo> BuscarPorId(int id);
    }
}
