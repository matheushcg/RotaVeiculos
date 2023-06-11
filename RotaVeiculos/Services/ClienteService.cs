using RotaVeiculos.Models;
using RotaVeiculos.Repositories.Interfaces;
using RotaVeiculos.Requests.Cliente;
using RotaVeiculos.Requests.Financa;
using RotaVeiculos.Services.Interfaces;
using RotaVeiculos.ViewModels.Cliente;
using RotaVeiculos.ViewModels.Financa;

namespace RotaVeiculos.Services
{
    public class ClienteService : IClienteService
    {
        IClienteRepositorio _clienteRepositorio;

        public ClienteService(IClienteRepositorio clienteRepositorio)
        {
            _clienteRepositorio = clienteRepositorio;
        }

        public async Task<ClienteViewModel> BuscarPorId(int id)
        {
            var response = await _clienteRepositorio.BuscarPorId(id);
            return response;
        }

        public async Task<List<ClienteGridViewModel>> BuscarTodosClientes(string nome)
        {
            var response = await _clienteRepositorio.BuscarTodosClientes(nome);
            return response;
        }

        public async Task<ClienteViewModel> Adicionar(ClienteRequest cliente)
        {
            var response = await _clienteRepositorio.Adicionar(cliente);
            return response;
        }

        public async Task<ClienteViewModel> Atualizar(int id, ClienteRequest cliente)
        {
            var clienteViewModel = await BuscarPorId(id);
            Cliente clientePorId = new Cliente(clienteViewModel.Id, clienteViewModel.Nome, clienteViewModel.Email, clienteViewModel.Cpf, clienteViewModel.Telefone);

            if (clientePorId != null)
            {
                var response = await _clienteRepositorio.Atualizar(id, cliente);
                return response;
            }
            else
            {
                throw new Exception("Cliente não foi encontrado");
            }
        }

        public async Task<bool> Deletar(int id)
        {
            var clienteViewModel = await BuscarPorId(id);
            Cliente clientePorId = new Cliente(clienteViewModel.Id, clienteViewModel.Nome, clienteViewModel.Email, clienteViewModel.Cpf, clienteViewModel.Telefone);

            if (clientePorId != null)
            {
                var response = await _clienteRepositorio.Deletar(id);
                return response;
            }
            else
            {
                throw new Exception("Cliente não foi encontrado");
            }
        }
    }
}
