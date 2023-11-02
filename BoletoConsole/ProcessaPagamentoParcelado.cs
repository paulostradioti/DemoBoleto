using BoletoConsole.Interfaces;

namespace Pagamento;

public class ProcessaPagamentoParcelado : ProcessaPagamento
{
    public void ProcessarPagamento<T>(T formaPagamento, double valor, int parcelas) where T : IPagamento, IParcelamento
    {
        formaPagamento.Parcelas = parcelas;
        formaPagamento.Pagar(valor);
    }
}
