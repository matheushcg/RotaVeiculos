using Azure.Core;
using Microsoft.EntityFrameworkCore;
using RotaVeiculos.Data;
using RotaVeiculos.Models;
using RotaVeiculos.Repositories.Interfaces;
using RotaVeiculos.Requests.Manutencao;
using RotaVeiculos.ViewModels.Usuario;
using RotaVeiculos.ViewModels.Manutencao;
using RotaVeiculos.ViewModels.Veiculo;

namespace RotaVeiculos.Repositories
{
    public class ManutencaoRepositorio : IManutencaoRepositorio
    {
        private readonly RotaVeiculosDBContext _dbContext;
        public ManutencaoRepositorio(RotaVeiculosDBContext rotaVeiculosDBContext)
        {
            _dbContext = rotaVeiculosDBContext;
        }

        public async Task<ManutencaoViewModel> BuscarPorId(int id)
        {
            var manutencao = await _dbContext.Manutencao.FirstOrDefaultAsync(x => x.Id == id);
            var veiculo = await _dbContext.Veiculos.FirstOrDefaultAsync(x => x.Id == manutencao.VeiculoId);
            var manutencaoViewModel = new ManutencaoViewModel(manutencao.Id, manutencao.Preco, manutencao.ManutencaoRealizada, manutencao.VeiculoId, veiculo.Nome, veiculo.Placa, veiculo.Imagem, veiculo.NomeImagem);
            return manutencaoViewModel;
        }

        public async Task<List<ManutencaoGridViewModel>> BuscarTodasManutencoes(string manutencaoRealizada)
        {
            var manutencaoList = await _dbContext.Manutencao.Where(x => manutencaoRealizada != null ? x.ManutencaoRealizada.Contains(manutencaoRealizada) : 1 == 1).ToListAsync();
            var manutencaoGridViewModel = new List<ManutencaoGridViewModel>();
            foreach (var manutencao in manutencaoList)
            {
                var veiculo = await _dbContext.Veiculos.FirstOrDefaultAsync(x => x.Id == manutencao.VeiculoId);
                var manutencaoToList = new ManutencaoGridViewModel(manutencao.Id, manutencao.Preco, manutencao.ManutencaoRealizada, manutencao.VeiculoId, veiculo.Nome, veiculo.Imagem, veiculo.NomeImagem);
                manutencaoGridViewModel.Add(manutencaoToList);
            }
            return manutencaoGridViewModel;
        }

        public async Task<ManutencaoViewModel> Adicionar(ManutencaoRequest request)
        {
            var manutencao = new Manutencao(0, request.Preco, request.ManutencaoRealizada, request.VeiculoId);
            await _dbContext.Manutencao.AddAsync(manutencao);
            await _dbContext.SaveChangesAsync();
            var manutencaoViewModel = await BuscarPorId(manutencao.Id);
            return manutencaoViewModel;
        }
        public async Task<ManutencaoViewModel> Atualizar(int id, ManutencaoRequest manutencao)
        {
            var manutencaoViewModel = await BuscarPorId(id);
            Manutencao manutencaoPorId = new Manutencao(manutencaoViewModel.Id, manutencaoViewModel.Preco, manutencaoViewModel.ManutencaoRealizada, manutencaoViewModel.VeiculoId);

            manutencaoPorId.Preco = manutencao.Preco;
            manutencaoPorId.ManutencaoRealizada = manutencao.ManutencaoRealizada;
            manutencaoPorId.VeiculoId = manutencao.VeiculoId;

            _dbContext.ChangeTracker.Clear();

            _dbContext.Manutencao.Update(manutencaoPorId);
            await _dbContext.SaveChangesAsync();

            manutencaoViewModel = await BuscarPorId(id);
            return manutencaoViewModel;
        }

        public async Task<bool> Deletar(int id)
        {
            var manutencaoViewModel = await BuscarPorId(id);
            Manutencao manutencaoPorId = new Manutencao(manutencaoViewModel.Id, manutencaoViewModel.Preco, manutencaoViewModel.ManutencaoRealizada, manutencaoViewModel.VeiculoId);

            _dbContext.ChangeTracker.Clear();
            _dbContext.Manutencao.Remove(manutencaoPorId);
            await _dbContext.SaveChangesAsync();
            return true;
        }
    }
}