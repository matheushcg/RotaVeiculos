namespace RotaVeiculos.Models
{
    public class Manutencao
    {
        public Manutencao()
        {

        }

        public Manutencao(int id, string nome, double preco, string manutencaoRealizada, string placa)
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
