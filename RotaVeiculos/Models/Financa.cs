using static System.Net.Mime.MediaTypeNames;

namespace RotaVeiculos.Models
{
    public class Financa
    {
        public Financa()
        {

        }

        public Financa(int id, string descricao, double valor, int tipoFinancaId)
        {
            Id = id;
            Descricao = descricao;
            Valor = valor;
            TipoFinancaId = tipoFinancaId;
        }

        public int Id { get; set; }
        public string Descricao { get; set; }
        public double Valor { get; set; }
        public int TipoFinancaId { get; set; }
        public virtual TipoFinanca TipoFinanca { get; set; }
    }
}
