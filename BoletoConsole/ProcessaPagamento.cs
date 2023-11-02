using BoletoConsole.Interfaces;

namespace Pagamento;

public class ProcessaPagamento : IProcessaPagamento
{
    public void ProcessarPagamento<T>(T formaPagamento, double valor) where T : IPagamento => formaPagamento.Pagar(valor);
}
