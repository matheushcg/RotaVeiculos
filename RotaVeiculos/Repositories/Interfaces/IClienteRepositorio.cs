using RotaVeiculos.Requests.Cliente;
using RotaVeiculos.ViewModels.Cliente;

namespace RotaVeiculos.Repositories.Interfaces
{
    public interface IClienteRepositorio
    {
        Task<List<ClienteGridViewModel>> BuscarTodosClientes(string nome);
        Task<ClienteViewModel> BuscarPorId(int id);
        Task<ClienteViewModel> Adicionar(ClienteRequest cliente);
        Task<ClienteViewModel> Atualizar(int id, ClienteRequest cliente);
        Task<bool> Deletar(int id);
    }
}
