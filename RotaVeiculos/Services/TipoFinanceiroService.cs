using RotaVeiculos.Models;
using RotaVeiculos.Repositories;
using RotaVeiculos.Repositories.Interfaces;
using RotaVeiculos.Services.Interfaces;

namespace RotaVeiculos.Services
{
    public class TipoFinanceiroService : ITipoFinanceiroService
    {
        ITipoFinancaRepositorio _tipoFinancaRepositorio;
        public TipoFinanceiroService(ITipoFinancaRepositorio tipoFinancaRepositorio)
        {
            _tipoFinancaRepositorio = tipoFinancaRepositorio;
        }

        public async Task<TipoFinanca> BuscarPorId(int id)
        {
            var response = await _tipoFinancaRepositorio.BuscarPorId(id);
            return response;
        }

        public async Task<List<TipoFinanca>> BuscarTodosTiposFinancas()
        {
            var response = await _tipoFinancaRepositorio.BuscarTodosTiposFinanca();
            return response;
        }
    }
}
