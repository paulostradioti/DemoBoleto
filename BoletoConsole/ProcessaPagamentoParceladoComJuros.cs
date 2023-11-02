using BoletoConsole.Interfaces;

namespace Pagamento;

public class ProcessaPagamentoParceladoComJuros : ProcessaPagamentoParcelado
{
    public void ProcessarPagamento<T>(T formaPagamento, double valor, int parcelas, double juros) where T : IPagamento, IParcelamento, IJuros
    {
        formaPagamento.TaxaJuros = juros;
        formaPagamento.Parcelas = parcelas;
        formaPagamento.Pagar(valor);
    }
}
