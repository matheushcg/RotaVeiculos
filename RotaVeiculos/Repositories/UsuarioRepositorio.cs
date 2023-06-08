using Microsoft.EntityFrameworkCore;
using RotaVeiculos.Data;
using RotaVeiculos.Models;
using RotaVeiculos.Repositories.Interfaces;
using RotaVeiculos.Requests.Usuario;
using RotaVeiculos.ViewModels.Usuario;

namespace RotaVeiculos.Repositories
{
    public class UsuarioRepositorio : IUsuarioRepositorio
    {
        private readonly RotaVeiculosDBContext _dbContext;
        ICargoRepositorio _cargoRepositorio;
        public UsuarioRepositorio(RotaVeiculosDBContext rotaVeiculosDBContext, ICargoRepositorio cargoRepositorio)
        {
            _dbContext = rotaVeiculosDBContext;
            _cargoRepositorio = cargoRepositorio;
        }

        public async Task<UsuarioViewModel> BuscarPorId(int id)
        {
            var usuario = await _dbContext.Usuarios.FirstOrDefaultAsync(x => x.Id == id);
            var cargo = await _cargoRepositorio.BuscarPorId(usuario.CargoId);
            var usuarioViewModel = new UsuarioViewModel(usuario.Id, usuario.Nome, usuario.Email, usuario.Senha, usuario.Cpf, usuario.Telefone, cargo.Id, cargo.NomeCargo);
            return usuarioViewModel;
        }

        public async Task<List<UsuarioGridViewModel>> BuscarTodosUsuarios(string nome)
        {
            var usuariosList = await _dbContext.Usuarios.Where(x => nome != null ? x.Nome.Contains(nome) : 1 == 1).ToListAsync();
            var usuariosGridViewModel = usuariosList.Select(x => new UsuarioGridViewModel(x.Id, x.Nome, x.Email, x.Telefone)).ToList();
            return usuariosGridViewModel;
        }
        public async Task<UsuarioViewModel> Adicionar(UsuarioRequest request)
        {
            var usuario = new Usuario(0, request.Nome, request.Email, request.Senha, request.Cpf, request.Telefone, request.CargoId);
            await _dbContext.Usuarios.AddAsync(usuario);
            await _dbContext.SaveChangesAsync();
            var usuarioViewModel = await BuscarPorId(usuario.Id);
            return usuarioViewModel;
        }

        public async Task<UsuarioViewModel> Atualizar(int id, UsuarioRequest usuario)
        {
            var usuarioViewModel = await BuscarPorId(id);
            Usuario usuarioPorId = new Usuario(usuarioViewModel.Id, usuarioViewModel.Nome, usuarioViewModel.Email, usuarioViewModel.Senha, usuarioViewModel.Cpf, usuarioViewModel.Telefone, usuarioViewModel.CargoId);

            var cargo = await _cargoRepositorio.BuscarPorId(usuario.CargoId);

            usuarioPorId.Nome = usuario.Nome;
            usuarioPorId.Email = usuario.Email;
            usuarioPorId.Senha = usuario.Senha;
            usuarioPorId.Cpf = usuario.Cpf;
            usuarioPorId.Telefone = usuario.Telefone;
            usuarioPorId.CargoId = cargo.Id;

            _dbContext.ChangeTracker.Clear();

            _dbContext.Usuarios.Update(usuarioPorId);
            await _dbContext.SaveChangesAsync();

            usuarioViewModel = await BuscarPorId(id);
            return usuarioViewModel;
        }

        public async Task<bool> Deletar(int id)
        {
            var usuarioViewModel = await BuscarPorId(id);
            Usuario usuarioPorId = new Usuario(usuarioViewModel.Id, usuarioViewModel.Nome, usuarioViewModel.Email, usuarioViewModel.Senha, usuarioViewModel.Cpf, usuarioViewModel.Telefone, usuarioViewModel.CargoId);
            
            _dbContext.ChangeTracker.Clear();
            _dbContext.Usuarios.Remove(usuarioPorId);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<Usuario> VerificarLoginValido(string email)
        {
            return await _dbContext.Usuarios.FirstOrDefaultAsync(x => x.Email == email);
        }
    }
}
