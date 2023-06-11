using RotaVeiculos.Requests.Cliente;
using RotaVeiculos.ViewModels.Cliente;

namespace RotaVeiculos.Services.Interfaces
{
    public interface IClienteService
    {
        Task<ClienteViewModel> BuscarPorId(int id);
        Task<List<ClienteGridViewModel>> BuscarTodosClientes(string descricao);
        Task<ClienteViewModel> Adicionar(ClienteRequest cliente);
        Task<ClienteViewModel> Atualizar(int id, ClienteRequest cliente);
        Task<bool> Deletar(int id);
    }
}
