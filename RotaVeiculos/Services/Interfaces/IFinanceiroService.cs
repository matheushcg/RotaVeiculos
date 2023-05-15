using Microsoft.AspNetCore.Mvc;
using RotaVeiculos.Requests.Financa;
using RotaVeiculos.ViewModels.Financa;

namespace RotaVeiculos.Services.Interfaces
{
    public interface IFinanceiroService
    {
        Task<FinancaViewModel> BuscarPorId(int id);
        Task<List<FinancaGridViewModel>> BuscarTodasFinancas();
        Task<FinancaViewModel> Adicionar(FinancaRequest usuario);
        Task<FinancaViewModel> Atualizar(int id, FinancaRequest usuario);
        Task<bool> Deletar(int id);
    }
}
