using RotaVeiculos.Models;
using RotaVeiculos.Repositories.Interfaces;
using RotaVeiculos.Services.Interfaces;

namespace RotaVeiculos.Services
{
    public class CargoService : ICargoService
    {
        ICargoRepositorio _cargoRepositorio; 

        public CargoService(ICargoRepositorio cargoRepositorio)
        {
            _cargoRepositorio = cargoRepositorio;   
        }

        public async Task<Cargo> BuscarPorId(int id)
        {
            var response = await _cargoRepositorio.BuscarPorId(id);
            return response;
        }

        public async Task<List<Cargo>> BuscarTodosCargos()
        {
            var response = await _cargoRepositorio.BuscarTodosCargos();
            return response;
        }
    }
}
