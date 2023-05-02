using RotaVeiculos.Models;

namespace RotaVeiculos.Services.Interfaces
{
    public interface IVeiculoService
    {
        Task<Veiculo> BuscarPorId(int id);
        Task<List<Veiculo>> BuscarTodosVeiculos();
        Task<Veiculo> Adicionar(Veiculo veiculo);
        Task<Veiculo> Atualizar(int id, Veiculo veiculo);
        Task<bool> Deletar(int id);
    }
}
