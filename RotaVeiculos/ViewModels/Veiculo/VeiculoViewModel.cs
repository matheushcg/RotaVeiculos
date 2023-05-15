using RotaVeiculos.Models;

namespace RotaVeiculos.ViewModels.Veiculo
{
    public class VeiculoViewModel
    {
        public VeiculoViewModel()
        {

        }

        public VeiculoViewModel(int id, string nome, double preco, double quilometragem, string placa, bool documentosEmDia, string imagem)
        {
            Id = id;
            Nome = nome;
            Preco = preco;
            Quilometragem = quilometragem;
            Placa = placa;
            DocumentosEmDia = documentosEmDia;
            Imagem = imagem;
        }

        public int Id { get; set; }
        public string Nome { get; set; }
        public double Preco { get; set; }
        public double Quilometragem { get; set; }
        public string Placa { get; set; }
        public bool DocumentosEmDia { get; set; }
        public string Imagem { get; set; }
    }
}
