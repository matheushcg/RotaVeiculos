using RotaVeiculos.Models;

namespace RotaVeiculos.Services.Interfaces
{
    public interface ITipoFinanceiroService
    {
        Task<List<TipoFinanca>> BuscarTodosTiposFinancas();
        Task<TipoFinanca> BuscarPorId(int id);
    }
}
