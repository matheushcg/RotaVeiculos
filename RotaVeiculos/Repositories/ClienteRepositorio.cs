using Microsoft.EntityFrameworkCore;
using RotaVeiculos.Data;
using RotaVeiculos.Models;
using RotaVeiculos.Repositories.Interfaces;
using RotaVeiculos.Requests.Cliente;
using RotaVeiculos.Requests.Financa;
using RotaVeiculos.ViewModels.Cliente;
using RotaVeiculos.ViewModels.Financa;

namespace RotaVeiculos.Repositories
{
    public class ClienteRepositorio : IClienteRepositorio
    {
        private readonly RotaVeiculosDBContext _dbContext;

        public ClienteRepositorio(RotaVeiculosDBContext rotaVeiculosDBContext)
        {
            _dbContext = rotaVeiculosDBContext;
        }

        public async Task<ClienteViewModel> BuscarPorId(int id)
        {
            var cliente = await _dbContext.Clientes.FirstOrDefaultAsync(x => x.Id == id);
            var clienteViewModel = new ClienteViewModel(cliente.Id, cliente.Nome, cliente.Email, cliente.Cpf, cliente.Telefone);
            return clienteViewModel;
        }

        public async Task<List<ClienteGridViewModel>> BuscarTodosClientes(string nome)
        {
            var clientesList = await _dbContext.Clientes.Where(x => nome != null ? x.Nome.Contains(nome) : 1 == 1).ToListAsync();
            var clientesGridViewModel = clientesList.Select(x => new ClienteGridViewModel(x.Id, x.Nome, x.Email, x.Cpf, x.Telefone)).ToList();
            return clientesGridViewModel;
        }
        public async Task<ClienteViewModel> Adicionar(ClienteRequest request)
        {
            var cliente = new Cliente(0, request.Nome, request.Email, request.Cpf.Replace(".", "").Replace("-", ""), request.Telefone.Replace("(", "").Replace(")", "").Replace("-", "").Replace(" ", ""));
            await _dbContext.Clientes.AddAsync(cliente);
            await _dbContext.SaveChangesAsync();
            var clienteViewModel = await BuscarPorId(cliente.Id);
            return clienteViewModel;
        }

        public async Task<ClienteViewModel> Atualizar(int id, ClienteRequest cliente)
        {
            var clienteViewModel = await BuscarPorId(id);
            Cliente clientePorId = new Cliente(clienteViewModel.Id, clienteViewModel.Nome, clienteViewModel.Email, clienteViewModel.Cpf, clienteViewModel.Telefone);

            clientePorId.Nome = cliente.Nome;
            clientePorId.Email = cliente.Email;
            clientePorId.Cpf = cliente.Cpf.Replace(".", "").Replace("-", "");
            clientePorId.Telefone = cliente.Telefone.Replace("(", "").Replace(")", "").Replace("-", "").Replace(" ", "");

            _dbContext.ChangeTracker.Clear();

            _dbContext.Clientes.Update(clientePorId);
            await _dbContext.SaveChangesAsync();

            clienteViewModel = await BuscarPorId(id);
            return clienteViewModel;
        }

        public async Task<bool> Deletar(int id)
        {
            var clienteViewModel = await BuscarPorId(id);
            Cliente clientePorId = new Cliente(clienteViewModel.Id, clienteViewModel.Nome, clienteViewModel.Email, clienteViewModel.Cpf, clienteViewModel.Telefone);

            _dbContext.ChangeTracker.Clear();
            _dbContext.Clientes.Remove(clientePorId);
            await _dbContext.SaveChangesAsync();
            return true;
        }
    }
}
