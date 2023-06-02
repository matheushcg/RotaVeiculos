using Azure.Core;
using Microsoft.EntityFrameworkCore;
using RotaVeiculos.Data;
using RotaVeiculos.Models;
using RotaVeiculos.Repositories.Interfaces;
using RotaVeiculos.Requests.Manutencao;
using RotaVeiculos.ViewModels.Usuario;
using RotaVeiculos.ViewModels.Manutencao;

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
            var manutencaoViewModel = new ManutencaoViewModel(manutencao.Id, manutencao.Nome, manutencao.Preco, manutencao.ManutencaoRealizada, manutencao.Placa);
            return manutencaoViewModel;
        }

        public async Task<List<ManutencaoGridViewModel>> BuscarTodasManutencoes()
        {
            var manutencaoList = await _dbContext.Manutencao.ToListAsync();
            var manutencaoGridViewModel = manutencaoList.Select(x => new ManutencaoGridViewModel(x.Id, x.Nome, x.Preco, x.ManutencaoRealizada)).ToList();
            return manutencaoGridViewModel;
        }

        public async Task<ManutencaoViewModel> Adicionar(ManutencaoRequest request)
        {
            var manutencao = new Manutencao(0, request.Nome, request.Preco, request.ManutencaoRealizada, request.Placa);
            await _dbContext.Manutencao.AddAsync(manutencao);
            await _dbContext.SaveChangesAsync();
            var manutencaoViewModel = await BuscarPorId(manutencao.Id);
            return manutencaoViewModel;
        }
        public async Task<ManutencaoViewModel> Atualizar(int id, ManutencaoRequest manutencao)
        {
            var manutencaoViewModel = await BuscarPorId(id);
            Manutencao manutencaoPorId = new Manutencao(manutencaoViewModel.Id, manutencaoViewModel.Nome, manutencaoViewModel.Preco, manutencaoViewModel.ManutencaoRealizada, manutencaoViewModel.Placa);

            manutencaoPorId.Nome = manutencao.Nome;
            manutencaoPorId.Preco = manutencao.Preco;
            manutencaoPorId.ManutencaoRealizada = manutencao.ManutencaoRealizada;
            manutencaoPorId.Placa = manutencao.Placa;

            _dbContext.ChangeTracker.Clear();

            _dbContext.Manutencao.Update(manutencaoPorId);
            await _dbContext.SaveChangesAsync();

            manutencaoViewModel = await BuscarPorId(id);
            return manutencaoViewModel;
        }

        public async Task<bool> Deletar(int id)
        {
            var manutencaoViewModel = await BuscarPorId(id);
            Manutencao manutencaoPorId = new Manutencao(manutencaoViewModel.Id, manutencaoViewModel.Nome, manutencaoViewModel.Preco, manutencaoViewModel.ManutencaoRealizada, manutencaoViewModel.Placa);

            _dbContext.ChangeTracker.Clear();
            _dbContext.Manutencao.Remove(manutencaoPorId);
            await _dbContext.SaveChangesAsync();
            return true;
        }
    }
}