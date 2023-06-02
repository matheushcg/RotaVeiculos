using RotaVeiculos.Models;

namespace RotaVeiculos.ViewModels.Manutencao
{
    public class ManutencaoViewModel
    {
        public ManutencaoViewModel()
        {

        }

        public ManutencaoViewModel(int id, string nome, double preco, string manutencaoRealizada, string placa)
        {
            Id = id;
            Nome = nome;
            Preco = preco;
            ManutencaoRealizada = manutencaoRealizada;
            Placa = placa;
        }

        public int Id { get; set; }
        public string Nome { get; set; }
        public double Preco { get; set; }
        public string ManutencaoRealizada { get; set; }
        public string Placa { get; set; }
    }
}
