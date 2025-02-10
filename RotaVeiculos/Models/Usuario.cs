namespace RotaVeiculos.Models
{
    public class Usuario
    {
        public Usuario()
        {

        }

        public Usuario(int id, string nome, string email, string senha, string cpf, string telefone, int cargoId)
        {
            Id = id;
            Nome = nome;
            Email = email;
            Senha = senha;
            Cpf = cpf;
            Telefone = telefone;
            CargoId = cargoId;
        }

        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public string Cpf { get; set; }
        public string Telefone { get; set; }
        public int CargoId { get; set; }
        public virtual Cargo Cargo { get; set; }
    }
}
