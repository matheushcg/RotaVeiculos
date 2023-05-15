using System.ComponentModel.DataAnnotations;

namespace RotaVeiculos.Requests.Financa
{
    public class FinancaRequest
    {
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string Descricao { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public double Valor { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public int TipoFinancaId { get; set; }
    }
}
