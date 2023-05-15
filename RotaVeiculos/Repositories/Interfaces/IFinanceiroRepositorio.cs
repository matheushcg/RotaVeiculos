using RotaVeiculos.Requests.Financa;
using RotaVeiculos.Requests.Usuario;
using RotaVeiculos.ViewModels.Financa;
using RotaVeiculos.ViewModels.Usuario;

namespace RotaVeiculos.Repositories.Interfaces
{
    public interface IFinanceiroRepositorio
    {
        Task<List<FinancaGridViewModel>> BuscarTodasFinancas();
        Task<FinancaViewModel> BuscarPorId(int id);
        Task<FinancaViewModel> Adicionar(FinancaRequest financa);
        Task<FinancaViewModel> Atualizar(int id, FinancaRequest financa);
        Task<bool> Deletar(int id);
    }
}
