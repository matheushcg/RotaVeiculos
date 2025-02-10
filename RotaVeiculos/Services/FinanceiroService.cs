using RotaVeiculos.Models;
using RotaVeiculos.Repositories;
using RotaVeiculos.Repositories.Interfaces;
using RotaVeiculos.Requests.Financa;
using RotaVeiculos.Requests.Usuario;
using RotaVeiculos.Services.Interfaces;
using RotaVeiculos.ViewModels.Financa;
using RotaVeiculos.ViewModels.Usuario;

namespace RotaVeiculos.Services
{
    public class FinanceiroService : IFinanceiroService
    {
        IFinanceiroRepositorio _financeiroRepositorio;

        public FinanceiroService(IFinanceiroRepositorio financeiroRepositorio)
        {
            _financeiroRepositorio = financeiroRepositorio;
        }

        public async Task<FinancaViewModel> BuscarPorId(int id)
        {
            var response = await _financeiroRepositorio.BuscarPorId(id);
            return response;
        }

        public async Task<List<FinancaGridViewModel>> BuscarTodasFinancas(string descricao)
        {
            var response = await _financeiroRepositorio.BuscarTodasFinancas(descricao);
            return response;
        }

        public async Task<FinancaViewModel> Adicionar(FinancaRequest financa)
        {
            var response = await _financeiroRepositorio.Adicionar(financa);
            return response;
        }

        public async Task<FinancaViewModel> Atualizar(int id, FinancaRequest financa)
        {
            var financaViewModel = await BuscarPorId(id);
            Financa financaPorId = new Financa(financaViewModel.Id, financaViewModel.Descricao, financaViewModel.Valor, financaViewModel.TipoFinancaId);

            if (financaPorId != null)
            {
                var response = await _financeiroRepositorio.Atualizar(id, financa);
                return response;
            }
            else
            {
                throw new Exception("Finança não foi encontrada");
            }
        }

        public async Task<bool> Deletar(int id)
        {
            var financaViewModel = await BuscarPorId(id);
            Financa financaPorId = new Financa(financaViewModel.Id, financaViewModel.Descricao, financaViewModel.Valor, financaViewModel.TipoFinancaId);

            if (financaPorId != null)
            {
                var response = await _financeiroRepositorio.Deletar(id);
                return response;
            }
            else
            {
                throw new Exception("Finança não foi encontrada");
            }
        }
    }
}
