using RotaVeiculos.Models;

namespace RotaVeiculos.Repositories.Interfaces
{
    public interface IVeiculoRepositorio
    {
        Task<List<Veiculo>> BuscarTodosVeiculos();
        Task<Veiculo> BuscarPorId(int id);
        Task<Veiculo> Adicionar(Veiculo veiculo);
        Task<Veiculo> Atualizar(int id, Veiculo usuario);
        Task<bool> Deletar(int id);
    }
}
