namespace RotaVeiculos.Models
{
    public class Veiculo
    {
        public Veiculo()
        {

        }

        public Veiculo(int id, string nome, double preco, double quilometragem, string placa, bool documentosEmDia, string nomeImagem, string imagem, int ano, string tipoCombustivel, string cor)
        {
            Id = id;
            Nome = nome;
            Preco = preco;
            Quilometragem = quilometragem;
            Placa = placa;
            DocumentosEmDia = documentosEmDia;
            NomeImagem = nomeImagem;
            Imagem = imagem;
            Ano = ano;
            TipoCombustivel = tipoCombustivel;
            Cor = cor;
        }

        public int Id { get; set; }
        public string Nome { get; set; }
        public double Preco { get; set; }
        public double Quilometragem { get; set; }
        public string Placa { get; set; }
        public bool DocumentosEmDia { get; set; }
        public string NomeImagem { get; set; }
        public string Imagem { get; set; }
        public int Ano { get; set; }
        public string TipoCombustivel { get; set; }
        public string Cor { get; set; }
    }
}
