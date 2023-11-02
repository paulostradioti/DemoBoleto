namespace BoletoConsole.FormasPagamento;

public class Boleto : FormaPagamento
{
    public Boleto(int codigoBoleto)
    {
        CodigoBoleto = codigoBoleto;
    }
    public int CodigoBoleto { get; }
    public override void Pagar(double valor)
    {
        Console.WriteLine($"Boleto {CodigoBoleto} emitido no valor de {valor}");
        
        base.Pagar(valor);
    }
    
}
