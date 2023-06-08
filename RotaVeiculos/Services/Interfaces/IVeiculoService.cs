using RotaVeiculos.Models;
using RotaVeiculos.Requests.Veiculo;
using RotaVeiculos.ViewModels.Veiculo;

namespace RotaVeiculos.Services.Interfaces
{
    public interface IVeiculoService
    {
        Task<VeiculoViewModel> BuscarPorId(int id);
        Task<List<VeiculoGridViewModel>> BuscarTodosVeiculos(string nome);
        Task<VeiculoViewModel> Adicionar(VeiculoRequest veiculo);
        Task<VeiculoViewModel> Atualizar(int id, VeiculoRequest veiculo);
        Task<bool> Deletar(int id);
    }
}
