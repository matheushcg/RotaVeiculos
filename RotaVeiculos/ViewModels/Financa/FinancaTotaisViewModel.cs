namespace RotaVeiculos.ViewModels.Financa
{
    public class FinancaTotaisViewModel
    {
        public FinancaTotaisViewModel()
        {

        }

        public FinancaTotaisViewModel(double entradas, double saidas, double total)
        {
            Entradas = entradas;
            Saidas = saidas;
            Total = total;
        }

        public double Entradas { get; set; }
        public double Saidas { get; set; }
        public double Total { get; set; }
    }
}
