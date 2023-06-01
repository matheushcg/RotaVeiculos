using Azure;
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

            if(veiculo != null)
            {
                var veiculoViewModel = new VeiculoViewModel(veiculo.Id, veiculo.Nome, veiculo.Preco, veiculo.Quilometragem, veiculo.Placa, veiculo.DocumentosEmDia, veiculo.NomeImagem, veiculo.Imagem, null, veiculo.Ano, veiculo.TipoCombustivel, veiculo.Cor);
                return veiculoViewModel;
            }
            else
            {
                return null;
            }
        }

        public async Task<List<VeiculoGridViewModel>> BuscarTodosVeiculos()
        {
            var veiculosList = await _dbContext.Veiculos.ToListAsync();
            var veiculosGridViewModel = new List<VeiculoGridViewModel>();
            foreach(var veiculo in veiculosList)
            {
                var caminho = @"C:\RotaVeiculosImages\" + veiculo.Imagem;
                byte[] bytesImagem = File.ReadAllBytes(caminho);
                var imagemBase64 = Convert.ToBase64String(bytesImagem);
                var veiculoToList = new VeiculoGridViewModel(veiculo.Id, veiculo.Nome, veiculo.Preco, veiculo.Placa, veiculo.Quilometragem, veiculo.Ano, imagemBase64);
                veiculosGridViewModel.Add(veiculoToList);
            }
            return veiculosGridViewModel;
        }

        public async Task<VeiculoViewModel> Adicionar(VeiculoRequest request, string nomeArquivo)
        {
            var veiculo = new Veiculo(0, request.Nome, request.Preco, request.Quilometragem, request.Placa, request.DocumentosEmDia, request.NomeImagem, nomeArquivo, request.Ano, request.TipoCombustivel, request.Cor);
            await _dbContext.Veiculos.AddAsync(veiculo);
            await _dbContext.SaveChangesAsync();
            var veiculoViewModel = await BuscarPorId(veiculo.Id);
            return veiculoViewModel;
        }
        public async Task<VeiculoViewModel> Atualizar(int id, VeiculoRequest veiculo, string nomeArquivo)
        {
            var veiculoViewModel = await BuscarPorId(id);
            Veiculo veiculoPorId = new Veiculo(veiculoViewModel.Id, veiculoViewModel.Nome, veiculoViewModel.Preco, veiculoViewModel.Quilometragem, veiculoViewModel.Placa, veiculoViewModel.DocumentosEmDia, veiculoViewModel.NomeImagem, veiculoViewModel.Imagem, veiculoViewModel.Ano, veiculoViewModel.TipoCombustivel, veiculoViewModel.Cor);

            veiculoPorId.Nome = veiculo.Nome;
            veiculoPorId.Preco = veiculo.Preco;
            veiculoPorId.Quilometragem = veiculo.Quilometragem;
            veiculoPorId.Placa = veiculo.Placa;
            veiculoPorId.DocumentosEmDia = veiculo.DocumentosEmDia;
            veiculoPorId.Imagem = nomeArquivo;
            veiculoPorId.Ano = veiculo.Ano;
            veiculoPorId.TipoCombustivel = veiculo.TipoCombustivel;
            veiculoPorId.Cor = veiculo.Cor;

            _dbContext.ChangeTracker.Clear();

            _dbContext.Veiculos.Update(veiculoPorId);
            await _dbContext.SaveChangesAsync();

            veiculoViewModel = await BuscarPorId(id);
            return veiculoViewModel;
        }

        public async Task<bool> Deletar(int id)
        {
            var veiculoViewModel = await BuscarPorId(id);
            Veiculo veiculoPorId = new Veiculo(veiculoViewModel.Id, veiculoViewModel.Nome, veiculoViewModel.Preco, veiculoViewModel.Quilometragem, veiculoViewModel.Placa, veiculoViewModel.DocumentosEmDia, veiculoViewModel.NomeImagem, veiculoViewModel.Imagem, veiculoViewModel.Ano, veiculoViewModel.TipoCombustivel, veiculoViewModel.Cor);

            _dbContext.ChangeTracker.Clear();
            _dbContext.Veiculos.Remove(veiculoPorId);
            await _dbContext.SaveChangesAsync();
            return true;
        }
    }
}
