namespace BoletoConsole.FormasPagamento;

public class CarneLoja : FormaPagamentoParcelada
{
    public override double ValorParcelas(double valor) => valor / Parcelas;
    public override void Pagar(double valor)
    {
        Console.WriteLine($"Pagamento realizado! Valor total: {valor}. Valor da parcela: {ValorParcelas(valor)}. Número de parcelas: {Parcelas}x");

        base.Pagar(valor);
    }
}
