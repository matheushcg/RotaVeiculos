using RotaVeiculos.Models;
using RotaVeiculos.Repositories;
using RotaVeiculos.Repositories.Interfaces;
using RotaVeiculos.Services.Interfaces;

namespace RotaVeiculos.Services
{
    public class VeiculoService : IVeiculoService
    {
        IVeiculoRepositorio _veiculoRepositorio;

        public VeiculoService(IVeiculoRepositorio veiculoRepositorio)
        {
            _veiculoRepositorio = veiculoRepositorio;
        }

        public async Task<Veiculo> BuscarPorId(int id)
        {
            var response = await _veiculoRepositorio.BuscarPorId(id);
            return response;
        }

        public async Task<List<Veiculo>> BuscarTodosVeiculos()
        {
            var response = await _veiculoRepositorio.BuscarTodosVeiculos();
            return response;
        }

        public async Task<Veiculo> Adicionar(Veiculo veiculo)
        {
            var response = await _veiculoRepositorio.Adicionar(veiculo);
            return response;
        }

        public async Task<Veiculo> Atualizar(int id, Veiculo veiculo)
        {
            Veiculo veiculoPorId = await BuscarPorId(id);

            if (veiculoPorId != null)
            {
                var response = await _veiculoRepositorio.Atualizar(id, veiculo);
                return response;
            }
            else
            {
                throw new Exception("Veículo não foi encontrado");
            }
        }

        public async Task<bool> Deletar(int id)
        {
            Veiculo veiculoPorId = await BuscarPorId(id);

            if (veiculoPorId != null)
            {
                var response = await _veiculoRepositorio.Deletar(id);
                return response;
            }
            else
            {
                throw new Exception("Veículo não foi encontrado");
            }
        }
    }
}
