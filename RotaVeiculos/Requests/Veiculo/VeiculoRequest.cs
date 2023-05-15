using System.ComponentModel.DataAnnotations;

namespace RotaVeiculos.Requests.Veiculo
{
    public class VeiculoRequest
    {
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public double Preco { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public double Quilometragem { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string Placa { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public bool DocumentosEmDia { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string Imagem { get; set; }
    }
}
