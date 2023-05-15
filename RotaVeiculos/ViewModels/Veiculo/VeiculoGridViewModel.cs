using RotaVeiculos.Models;

namespace RotaVeiculos.ViewModels.Veiculo
{
    public class VeiculoGridViewModel
    {
        public VeiculoGridViewModel()
        {

        }

        public VeiculoGridViewModel(int id, string nome, double preco, string placa)
        {
            Id = id;
            Nome = nome;
            Preco = preco;
            Placa = placa;
        }
        public int Id { get; set; }
        public string Nome { get; set; }
        public double Preco { get; set; }
        public string Placa { get; set; }
    }
}
