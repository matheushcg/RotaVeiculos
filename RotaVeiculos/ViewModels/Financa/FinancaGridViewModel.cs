namespace RotaVeiculos.ViewModels.Financa
{
    public class FinancaGridViewModel
    {
        public FinancaGridViewModel()
        {

        }

        public FinancaGridViewModel(int id, string descricao, double valor, string tipoFinancaNome)
        {
            Id = id;
            Descricao = descricao;
            Valor = valor;
            TipoFinancaNome = tipoFinancaNome;
        }

        public int Id { get; set; }
        public string Descricao { get; set; }
        public double Valor { get; set; }
        public string TipoFinancaNome { get; set; }
    }
}
