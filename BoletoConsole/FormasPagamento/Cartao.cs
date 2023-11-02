using BoletoConsole.Interfaces;

namespace BoletoConsole.FormasPagamento;

public class Cartao : FormaPagamentoParceladaComJuros, IJuros
{
    public override void Pagar(double valor)
    {
        Console.WriteLine($"Pagamento realizado! Valor total: {ValorTotal(valor)}. Valor juros: {ValorJuros(valor)}. Valor da parcela: {ValorParcelas(valor)}. Número de parcelas: {Parcelas}x");

        base.Pagar(valor);
    }
}
