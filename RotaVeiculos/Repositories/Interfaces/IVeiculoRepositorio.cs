using RotaVeiculos.Models;
using RotaVeiculos.Requests.Veiculo;
using RotaVeiculos.ViewModels.Veiculo;

namespace RotaVeiculos.Repositories.Interfaces
{
    public interface IVeiculoRepositorio
    {
        Task<List<VeiculoGridViewModel>> BuscarTodosVeiculos();
        Task<VeiculoViewModel> BuscarPorId(int id);
        Task<VeiculoViewModel> Adicionar(VeiculoRequest veiculo, string nomeArquivo);
        Task<VeiculoViewModel> Atualizar(int id, VeiculoRequest usuario, string nomeArquivo);
        Task<bool> Deletar(int id);
    }
}
