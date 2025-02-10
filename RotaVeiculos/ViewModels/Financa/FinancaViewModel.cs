using RotaVeiculos.Models;
using RotaVeiculos.ViewModels.Usuario;
using System.Drawing;

namespace RotaVeiculos.ViewModels.Financa
{
    public class FinancaViewModel
    {
        public FinancaViewModel()
        {
            
        }

        public FinancaViewModel(int id, string descricao, double valor, int tipoFinancaId, string tipoFinancaNome)
        {
            Id = id;
            Descricao = descricao;
            Valor = valor;
            TipoFinancaId = tipoFinancaId;
            TipoFinancaNome = tipoFinancaNome;
        }

        public int Id { get; set; }
        public string Descricao { get; set; }
        public double Valor { get; set; }
        public int TipoFinancaId { get; set; }
        public string TipoFinancaNome { get; set; }
    }
}
