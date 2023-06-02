using RotaVeiculos.Models;
using RotaVeiculos.Requests.Manutencao;
using RotaVeiculos.ViewModels.Manutencao;

namespace RotaVeiculos.Repositories.Interfaces
{
    public interface IManutencaoRepositorio
    {
        Task<List<ManutencaoGridViewModel>> BuscarTodasManutencoes();
        Task<ManutencaoViewModel> BuscarPorId(int id);
        Task<ManutencaoViewModel> Adicionar(ManutencaoRequest manutencao);
        Task<ManutencaoViewModel> Atualizar(int id, ManutencaoRequest usuario);
        Task<bool> Deletar(int id);
    }
}