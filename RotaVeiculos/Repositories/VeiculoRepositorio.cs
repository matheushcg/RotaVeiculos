using Azure.Core;
using Microsoft.EntityFrameworkCore;
using RotaVeiculos.Data;
using RotaVeiculos.Models;
using RotaVeiculos.Repositories.Interfaces;
using RotaVeiculos.Requests.Veiculo;
using RotaVeiculos.ViewModels.Usuario;
using RotaVeiculos.ViewModels.Veiculo;

namespace RotaVeiculos.Repositories
{
    public class VeiculoRepositorio : IVeiculoRepositorio
    {
        private readonly RotaVeiculosDBContext _dbContext;
        public VeiculoRepositorio(RotaVeiculosDBContext rotaVeiculosDBContext)
        {
            _dbContext = rotaVeiculosDBContext;
        }

        public async Task<VeiculoViewModel> BuscarPorId(int id)
        {
            var veiculo = await _dbContext.Veiculos.FirstOrDefaultAsync(x => x.Id == id);
            var veiculoViewModel = new VeiculoViewModel(veiculo.Id, veiculo.Nome, veiculo.Preco, veiculo.Quilometragem, veiculo.Placa, veiculo.DocumentosEmDia, veiculo.Imagem);
            return veiculoViewModel;
        }

        public async Task<List<VeiculoGridViewModel>> BuscarTodosVeiculos()
        {
            var veiculosList = await _dbContext.Veiculos.ToListAsync();
            var veiculosGridViewModel = veiculosList.Select(x => new VeiculoGridViewModel(x.Id, x.Nome, x.Preco, x.Placa)).ToList();
            return veiculosGridViewModel;
        }

        public async Task<VeiculoViewModel> Adicionar(VeiculoRequest request)
        {
            var veiculo = new Veiculo(0, request.Nome, request.Preco, request.Quilometragem, request.Placa, request.DocumentosEmDia, request.Imagem);
            await _dbContext.Veiculos.AddAsync(veiculo);
            await _dbContext.SaveChangesAsync();
            var veiculoViewModel = await BuscarPorId(veiculo.Id);
            return veiculoViewModel;
        }
        public async Task<VeiculoViewModel> Atualizar(int id, VeiculoRequest veiculo)
        {
            var veiculoViewModel = await BuscarPorId(id);
            Veiculo veiculoPorId = new Veiculo(veiculoViewModel.Id, veiculoViewModel.Nome, veiculoViewModel.Preco, veiculoViewModel.Quilometragem, veiculoViewModel.Placa, veiculoViewModel.DocumentosEmDia, veiculoViewModel.Imagem);

            veiculoPorId.Nome = veiculo.Nome;
            veiculoPorId.Preco = veiculo.Preco;
            veiculoPorId.Quilometragem = veiculo.Quilometragem;
            veiculoPorId.Placa = veiculo.Placa;
            veiculoPorId.DocumentosEmDia = veiculo.DocumentosEmDia;
            veiculoPorId.Imagem = veiculo.Imagem;

            _dbContext.ChangeTracker.Clear();

            _dbContext.Veiculos.Update(veiculoPorId);
            await _dbContext.SaveChangesAsync();

            veiculoViewModel = await BuscarPorId(id);
            return veiculoViewModel;
        }

        public async Task<bool> Deletar(int id)
        {
            var veiculoViewModel = await BuscarPorId(id);
            Veiculo veiculoPorId = new Veiculo(veiculoViewModel.Id, veiculoViewModel.Nome, veiculoViewModel.Preco, veiculoViewModel.Quilometragem, veiculoViewModel.Placa, veiculoViewModel.DocumentosEmDia, veiculoViewModel.Imagem);

            _dbContext.ChangeTracker.Clear();
            _dbContext.Veiculos.Remove(veiculoPorId);
            await _dbContext.SaveChangesAsync();
            return true;
        }
    }
}
