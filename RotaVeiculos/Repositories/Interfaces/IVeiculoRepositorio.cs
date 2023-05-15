using RotaVeiculos.Models;
using RotaVeiculos.Requests.Veiculo;
using RotaVeiculos.ViewModels.Veiculo;

namespace RotaVeiculos.Repositories.Interfaces
{
    public interface IVeiculoRepositorio
    {
        Task<List<VeiculoGridViewModel>> BuscarTodosVeiculos();
        Task<VeiculoViewModel> BuscarPorId(int id);
        Task<VeiculoViewModel> Adicionar(VeiculoRequest veiculo);
        Task<VeiculoViewModel> Atualizar(int id, VeiculoRequest usuario);
        Task<bool> Deletar(int id);
    }
}
