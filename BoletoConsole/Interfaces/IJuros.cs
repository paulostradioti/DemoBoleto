namespace BoletoConsole.Interfaces;

public interface IJuros
{
    public double TaxaJuros { get; set; }
    public double ValorJuros(double valor);
    public double ValorTotal(double valor);
}
