namespace BoletoConsole.Interfaces;

public interface IProcessaPagamento
{
    public void ProcessarPagamento<T>(T formaPagamento, double valor) where T : IPagamento => formaPagamento.Pagar(valor);
}
