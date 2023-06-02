using RotaVeiculos.Models;

namespace RotaVeiculos.ViewModels.Manutencao
{
    public class ManutencaoGridViewModel
    {
        public ManutencaoGridViewModel()
        {

        }

        public ManutencaoGridViewModel(int id, string nome, double preco, string manutencaoRealizada, string imagemBase64)
        {
            Id = id;
            Nome = nome;
            Preco = preco;
            ManutencaoRealizada = manutencaoRealizada;
            ImagemBase64 = imagemBase64;
        }

        public int Id { get; set; }
        public string Nome { get; set; }
        public double Preco { get; set; }
        public string ManutencaoRealizada { get; set; }
        public string ImagemBase64 { get; set; }
    }
}
