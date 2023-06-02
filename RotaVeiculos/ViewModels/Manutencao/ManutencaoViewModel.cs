using RotaVeiculos.Models;
using static System.Net.Mime.MediaTypeNames;

namespace RotaVeiculos.ViewModels.Manutencao
{
    public class ManutencaoViewModel
    {
        public ManutencaoViewModel()
        {

        }

        public ManutencaoViewModel(int id, string nome, double preco, string manutencaoRealizada, string placa, string nomeImagem, string imagem, string imagemBase64)
        {
            Id = id;
            Nome = nome;
            Preco = preco;
            ManutencaoRealizada = manutencaoRealizada;
            Placa = placa;
            NomeImagem = nomeImagem;
            Imagem = imagem;
            ImagemBase64 = imagemBase64;
        }

        public int Id { get; set; }
        public string Nome { get; set; }
        public double Preco { get; set; }
        public string ManutencaoRealizada { get; set; }
        public string Placa { get; set; }
        public string NomeImagem { get; set; }
        public string Imagem { get; set; }
        public string ImagemBase64 { get; set; }
    }
}
