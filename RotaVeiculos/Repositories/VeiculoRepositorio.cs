using Microsoft.EntityFrameworkCore;
using RotaVeiculos.Data;
using RotaVeiculos.Models;
using RotaVeiculos.Repositories.Interfaces;

namespace RotaVeiculos.Repositories
{
    public class VeiculoRepositorio : IVeiculoRepositorio
    {
        private readonly RotaVeiculosDBContext _dbContext;
        public VeiculoRepositorio(RotaVeiculosDBContext rotaVeiculosDBContext)
        {
            _dbContext = rotaVeiculosDBContext;
        }

        public async Task<Veiculo> BuscarPorId(int id)
        {
            return await _dbContext.Veiculos.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<Veiculo>> BuscarTodosVeiculos()
        {
            return await _dbContext.Veiculos.ToListAsync();
        }

        public async Task<Veiculo> Adicionar(Veiculo veiculo)
        {
            await _dbContext.Veiculos.AddAsync(veiculo);
            await _dbContext.SaveChangesAsync();

            return veiculo;
        }

        public async Task<Veiculo> Atualizar(int id, Veiculo veiculo)
        {
            Veiculo veiculoPorId = await BuscarPorId(id);

            veiculoPorId.Nome = veiculo.Nome;
            veiculoPorId.Preco = veiculo.Preco;
            veiculoPorId.Quilometragem = veiculo.Quilometragem;
            veiculoPorId.Placa = veiculo.Placa;
            veiculoPorId.DocumentosEmDia = veiculo.DocumentosEmDia;
            veiculoPorId.Imagem = veiculo.Imagem;

            _dbContext.Veiculos.Update(veiculoPorId);
            await _dbContext.SaveChangesAsync();

            return veiculoPorId;
        }

        public async Task<bool> Deletar(int id)
        {
            Veiculo veiculoPorId = await BuscarPorId(id);

            _dbContext.Veiculos.Remove(veiculoPorId);
            await _dbContext.SaveChangesAsync();
            return true;
        }
    }
}
