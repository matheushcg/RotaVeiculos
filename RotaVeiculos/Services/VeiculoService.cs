using RotaVeiculos.Models;
using RotaVeiculos.Repositories;
using RotaVeiculos.Repositories.Interfaces;
using RotaVeiculos.Requests.Veiculo;
using RotaVeiculos.Services.Interfaces;
using RotaVeiculos.ViewModels.Veiculo;

namespace RotaVeiculos.Services
{
    public class VeiculoService : IVeiculoService
    {
        IVeiculoRepositorio _veiculoRepositorio;

        public VeiculoService(IVeiculoRepositorio veiculoRepositorio)
        {
            _veiculoRepositorio = veiculoRepositorio;
        }

        public async Task<VeiculoViewModel> BuscarPorId(int id)
        {
            var response = await _veiculoRepositorio.BuscarPorId(id);
            return response;
        }

        public async Task<List<VeiculoGridViewModel>> BuscarTodosVeiculos()
        {
            var response = await _veiculoRepositorio.BuscarTodosVeiculos();
            return response;
        }

        public async Task<VeiculoViewModel> Adicionar(VeiculoRequest veiculo)
        {
            var response = await _veiculoRepositorio.Adicionar(veiculo);
            return response;
        }

        public async Task<VeiculoViewModel> Atualizar(int id, VeiculoRequest veiculo)
        {
            var veiculoViewModel = await BuscarPorId(id);
            Veiculo veiculoPorId = new Veiculo(veiculoViewModel.Id, veiculoViewModel.Nome, veiculoViewModel.Preco, veiculoViewModel.Quilometragem, veiculoViewModel.Placa, veiculoViewModel.DocumentosEmDia, veiculoViewModel.Imagem);

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
            var veiculoViewModel = await BuscarPorId(id);
            Veiculo veiculoPorId = new Veiculo(veiculoViewModel.Id, veiculoViewModel.Nome, veiculoViewModel.Preco, veiculoViewModel.Quilometragem, veiculoViewModel.Placa, veiculoViewModel.DocumentosEmDia, veiculoViewModel.Imagem);

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
