namespace RotaVeiculos.Models
{
    public class Veiculo
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public double Preco { get; set; }
        public double Quilometragem { get; set; }
        public string Placa { get; set; }
        public bool DocumentosEmDia { get; set; }
        public string Imagem { get; set; }
    }
}
