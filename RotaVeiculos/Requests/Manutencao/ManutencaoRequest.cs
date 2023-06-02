using System.ComponentModel.DataAnnotations;

namespace RotaVeiculos.Requests.Manutencao;

public class ManutencaoRequest
{
    [Required(ErrorMessage = "O campo {0} é obrigatório")]
    public string Nome { get; set; }

    [Required(ErrorMessage = "O campo {0} é obrigatório")]
    public double Preco { get; set; }

    [Required(ErrorMessage = "O campo {0} é obrigatório")]
    public string ManutencaoRealizada { get; set; }

    [Required(ErrorMessage = "O campo {0} é obrigatório")]
    public string Placa { get; set; }

    [Required(ErrorMessage = "O campo {0} é obrigatório")]
    public string NomeImagem { get; set; }

    [Required(ErrorMessage = "O campo {0} é obrigatório")]
    public string ImagemBase64 { get; set; }
}
