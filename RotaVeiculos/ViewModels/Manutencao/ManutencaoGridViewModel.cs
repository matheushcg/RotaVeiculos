using RotaVeiculos.Models;

namespace RotaVeiculos.ViewModels.Manutencao
{
    public class ManutencaoGridViewModel
    {
        public ManutencaoGridViewModel()
        {

        }

        public ManutencaoGridViewModel(int id, string nome, double preco, string manutencaoRealizada)
        {
            Id = id;
            Nome = nome;
            Preco = preco;
            ManutencaoRealizada = manutencaoRealizada;
        }

        public int Id { get; set; }
        public string Nome { get; set; }
        public double Preco { get; set; }
        public string ManutencaoRealizada { get; set; }
    }
}
