using Microsoft.EntityFrameworkCore;
using RotaVeiculos.Data;
using RotaVeiculos.Models;
using RotaVeiculos.Repositories.Interfaces;

namespace RotaVeiculos.Repositories
{
    public class UsuarioRepositorio : IUsuarioRepositorio
    {
        private readonly RotaVeiculosDBContext _dbContext;
        public UsuarioRepositorio(RotaVeiculosDBContext rotaVeiculosDBContext)
        {
            _dbContext = rotaVeiculosDBContext;
        }

        public async Task<Usuario> BuscarPorId(int id)
        {
            return await _dbContext.Usuarios.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<Usuario>> BuscarTodosUsuarios()
        {
            return await _dbContext.Usuarios.ToListAsync();
        }
        public async Task<Usuario> Adicionar(Usuario usuario)
        {
            await _dbContext.Usuarios.AddAsync(usuario);
            await _dbContext.SaveChangesAsync();

            return usuario;
        }

        public async Task<Usuario> Atualizar(int id, Usuario usuario)
        {
            Usuario usuarioPorId = await BuscarPorId(id);

            if(usuarioPorId == null)
            {
                throw new Exception("Usuário não foi encontrado");
            }

            usuarioPorId.Nome = usuario.Nome;
            usuarioPorId.Email = usuario.Email;
            usuarioPorId.Senha = usuario.Senha;
            usuarioPorId.Cpf = usuario.Cpf;
            usuarioPorId.Telefone = usuario.Telefone;
            usuarioPorId.Cargo = usuario.Cargo;

            _dbContext.Usuarios.Update(usuarioPorId);
            await _dbContext.SaveChangesAsync();

            return usuarioPorId;
        }

        public async Task<bool> Deletar(int id)
        {
            Usuario usuarioPorId = await BuscarPorId(id);

            if (usuarioPorId == null)
            {
                throw new Exception("Usuário não foi encontrado");
            }

            _dbContext.Usuarios.Remove(usuarioPorId);
            await _dbContext.SaveChangesAsync();
            return true;
        }
    }
}
