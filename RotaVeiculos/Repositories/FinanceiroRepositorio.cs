using Microsoft.EntityFrameworkCore;
using RotaVeiculos.Data;
using RotaVeiculos.Models;
using RotaVeiculos.Repositories.Interfaces;
using RotaVeiculos.Requests.Financa;
using RotaVeiculos.Requests.Usuario;
using RotaVeiculos.ViewModels.Financa;
using RotaVeiculos.ViewModels.Usuario;

namespace RotaVeiculos.Repositories
{
    public class FinanceiroRepositorio : IFinanceiroRepositorio
    {
        private readonly RotaVeiculosDBContext _dbContext;
        ITipoFinancaRepositorio _tipoFinancaRepositorio;
        public FinanceiroRepositorio(RotaVeiculosDBContext rotaVeiculosDBContext, ITipoFinancaRepositorio tipoFinancaRepositorio)
        {
            _dbContext = rotaVeiculosDBContext;
            _tipoFinancaRepositorio = tipoFinancaRepositorio;
        }

        public async Task<FinancaViewModel> BuscarPorId(int id)
        {
            var financa = await _dbContext.Financas.FirstOrDefaultAsync(x => x.Id == id);
            var tipoFinanca = await _tipoFinancaRepositorio.BuscarPorId(financa.TipoFinancaId);
            var tipoFinancaViewModel = new FinancaViewModel(financa.Id, financa.Descricao, financa.Valor, tipoFinanca.Id, tipoFinanca.NomeTipoFinanca);
            return tipoFinancaViewModel;
        }

        public async Task<List<FinancaGridViewModel>> BuscarTodasFinancas(string descricao)
        {
            var financasList = await _dbContext.Financas.Where(x => descricao != null ? x.Descricao.Contains(descricao) : 1 == 1).ToListAsync();
            var tipoFinancasList = await _tipoFinancaRepositorio.BuscarTodosTiposFinanca();
            var financasGridViewModel = financasList.Select(x => new FinancaGridViewModel(x.Id, x.Descricao, x.Valor, tipoFinancasList.Where(y => y.Id == x.TipoFinancaId).FirstOrDefault().NomeTipoFinanca)).ToList();
            return financasGridViewModel;
        }
        public async Task<FinancaViewModel> Adicionar(FinancaRequest request)
        {
            var financa = new Financa(0, request.Descricao, request.Valor, request.TipoFinancaId);
            await _dbContext.Financas.AddAsync(financa);
            await _dbContext.SaveChangesAsync();
            var financaViewModel = await BuscarPorId(financa.Id);
            return financaViewModel;
        }

        public async Task<FinancaViewModel> Atualizar(int id, FinancaRequest financa)
        {
            var financaViewModel = await BuscarPorId(id);
            Financa financaPorId = new Financa(financaViewModel.Id, financaViewModel.Descricao, financaViewModel.Valor, financaViewModel.TipoFinancaId);

            var tipoFinanca = await _tipoFinancaRepositorio.BuscarPorId(financa.TipoFinancaId);

            financaPorId.Descricao = financa.Descricao;
            financaPorId.Valor = financa.Valor;
            financaPorId.TipoFinancaId = tipoFinanca.Id;

            _dbContext.ChangeTracker.Clear();

            _dbContext.Financas.Update(financaPorId);
            await _dbContext.SaveChangesAsync();

            financaViewModel = await BuscarPorId(id);
            return financaViewModel;
        }

        public async Task<bool> Deletar(int id)
        {
            var financaViewModel = await BuscarPorId(id);
            Financa financaPorId = new Financa(financaViewModel.Id, financaViewModel.Descricao, financaViewModel.Valor, financaViewModel.TipoFinancaId);

            _dbContext.ChangeTracker.Clear();
            _dbContext.Financas.Remove(financaPorId);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<List<Financa>> BuscarTotais()
        {
            var financasList = await _dbContext.Financas.ToListAsync();
            return financasList;
        }
    }
}
