using Microsoft.EntityFrameworkCore;
using RotaVeiculos.Data;
using RotaVeiculos.Models;
using RotaVeiculos.Repositories.Interfaces;

namespace RotaVeiculos.Repositories
{
    public class TipoFinancaRepositorio : ITipoFinancaRepositorio
    {
        private readonly RotaVeiculosDBContext _dbContext;
        public TipoFinancaRepositorio(RotaVeiculosDBContext rotaVeiculosDBContext)
        {
            _dbContext = rotaVeiculosDBContext;
        }
        public async Task<TipoFinanca> BuscarPorId(int id)
        {
            return await _dbContext.TiposFinanca.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<TipoFinanca>> BuscarTodosTiposFinanca()
        {
            return await _dbContext.TiposFinanca.ToListAsync();
        }
    }
}
