using Microsoft.EntityFrameworkCore;
using RotaVeiculos.Data;
using RotaVeiculos.Models;
using RotaVeiculos.Repositories.Interfaces;

namespace RotaVeiculos.Repositories
{
    public class CargoRepositorio : ICargoRepositorio
    {
        private readonly RotaVeiculosDBContext _dbContext;
        public CargoRepositorio(RotaVeiculosDBContext rotaVeiculosDBContext)
        {
            _dbContext = rotaVeiculosDBContext;
        }
        public async Task<Cargo> BuscarPorId(int id)
        {
            return await _dbContext.Cargos.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<Cargo>> BuscarTodosCargos()
        {
            return await _dbContext.Cargos.ToListAsync();
        }

    }
}
