using RotaVeiculos.Models;

namespace RotaVeiculos.Repositories.Interfaces
{
    public interface ITipoFinancaRepositorio
    {
        Task<List<TipoFinanca>> BuscarTodosTiposFinanca();
        Task<TipoFinanca> BuscarPorId(int id);
    }
}
