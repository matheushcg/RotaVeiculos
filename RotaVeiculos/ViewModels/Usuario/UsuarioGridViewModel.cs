using RotaVeiculos.Models;

namespace RotaVeiculos.ViewModels.Usuario
{
    public class UsuarioGridViewModel
    {
        public UsuarioGridViewModel()
        {

        }

        public UsuarioGridViewModel(int id, string nome, string email, string cpf, string telefone, int cargoId, string cargoNome)
        {
            Id = id;
            Nome = nome;
            Email = email;
            Cpf = cpf;
            Telefone = telefone;
            CargoId = cargoId;
            CargoNome = cargoNome;
        }

        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Cpf { get; set; }
        public string Telefone { get; set; }
        public int CargoId { get; set; }
        public string CargoNome { get; set; }
    }
}
