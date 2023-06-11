namespace RotaVeiculos.Models
{
    public class Manutencao
    {
        public Manutencao()
        {

        }

        public Manutencao(int id, double preco, string manutencaoRealizada, int veiculoId)
        {
            Id = id;
            Preco = preco;
            ManutencaoRealizada = manutencaoRealizada;
            VeiculoId = veiculoId;
        }

        public int Id { get; set; }
        public double Preco { get; set; }
        public string ManutencaoRealizada { get; set; }
        public int VeiculoId { get; set; }
        public virtual Veiculo Veiculo { get; set; }
    }
}
