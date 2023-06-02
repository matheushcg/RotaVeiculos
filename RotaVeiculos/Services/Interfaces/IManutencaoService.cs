using RotaVeiculos.Models;
using RotaVeiculos.Requests.Manutencao;
using RotaVeiculos.ViewModels.Manutencao;

namespace RotaVeiculos.Services.Interfaces
{
    public interface IManutencaoService
    {
        Task<ManutencaoViewModel> BuscarPorId(int id);
        Task<List<ManutencaoGridViewModel>> BuscarTodasManutencoes();
        Task<ManutencaoViewModel> Adicionar(ManutencaoRequest manutencao);
        Task<ManutencaoViewModel> Atualizar(int id, ManutencaoRequest manutencao);
        Task<bool> Deletar(int id);
    }
}
