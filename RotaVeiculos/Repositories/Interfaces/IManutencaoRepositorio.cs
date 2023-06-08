using RotaVeiculos.Models;
using RotaVeiculos.Requests.Manutencao;
using RotaVeiculos.ViewModels.Manutencao;

namespace RotaVeiculos.Repositories.Interfaces
{
    public interface IManutencaoRepositorio
    {
        Task<List<ManutencaoGridViewModel>> BuscarTodasManutencoes(string nome);
        Task<ManutencaoViewModel> BuscarPorId(int id);
        Task<ManutencaoViewModel> Adicionar(ManutencaoRequest manutencao, string nomeArquivo);
        Task<ManutencaoViewModel> Atualizar(int id, ManutencaoRequest usuario, string nomeArquivo);
        Task<bool> Deletar(int id);
    }
}