namespace BoletoConsole.Interfaces;

public interface IParcelamento
{
    public int Parcelas { get; set; }
    public double ValorParcelas(double valor);
}
