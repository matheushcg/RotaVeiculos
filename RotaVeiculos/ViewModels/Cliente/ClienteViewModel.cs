namespace RotaVeiculos.ViewModels.Cliente
{
    public class ClienteViewModel
    {
        public ClienteViewModel()
        {

        }

        public ClienteViewModel(int id, string nome, string email, string cpf, string telefone)
        {
            Id = id;
            Nome = nome;
            Email = email;
            Cpf = cpf;
            Telefone = telefone;
        }

        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Cpf { get; set; }
        public string Telefone { get; set; }
    }
}
