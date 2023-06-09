using RotaVeiculos.Models;

namespace RotaVeiculos.ViewModels.Veiculo
{
    public class VeiculoGridViewModel
    {
        public VeiculoGridViewModel()
        {

        }

        public VeiculoGridViewModel(int id, string nome, double preco, string placa, double quilometragem, int ano, string imagem)
        {
            Id = id;
            Nome = nome;
            Preco = preco;
            Placa = placa;
            Quilometragem = quilometragem;
            Ano = ano;
            Imagem = imagem;
        }
        public int Id { get; set; }
        public string Nome { get; set; }
        public double Preco { get; set; }
        public string Placa { get; set; }
        public double Quilometragem { get; set; }
        public int Ano { get; set; }
        public string Imagem { get; set; }
    }
}
