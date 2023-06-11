using RotaVeiculos.Models;
using static System.Net.Mime.MediaTypeNames;

namespace RotaVeiculos.ViewModels.Manutencao
{
    public class ManutencaoViewModel
    {
        public ManutencaoViewModel()
        {

        }

        public ManutencaoViewModel(int id, double preco, string manutencaoRealizada, int veiculoId, string veiculoNome, string veiculoPlaca, string veiculoImagem, string veiculoNomeImagem)
        {
            Id = id;
            Preco = preco;
            ManutencaoRealizada = manutencaoRealizada;
            VeiculoId = veiculoId;
            VeiculoNome = veiculoNome;
            VeiculoPlaca = veiculoPlaca;
            VeiculoImagem = veiculoImagem;
            VeiculoNomeImagem = veiculoNomeImagem;
        }

        public int Id { get; set; }
        public double Preco { get; set; }
        public string ManutencaoRealizada { get; set; }
        public int VeiculoId { get; set; }
        public string VeiculoNome { get; set; }
        public string VeiculoPlaca { get; set; }
        public string VeiculoImagem { get; set; }
        public string VeiculoNomeImagem { get; set; }
    }
}
