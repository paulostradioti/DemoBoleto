using BoletoConsole.Interfaces;

namespace BoletoConsole.FormasPagamento;

public abstract class FormaPagamento : IPagamento
{
    protected bool Pago { get; set; } = false;

    public virtual void Pagar(double valor)
    { 
        Pago = true;
    }
}
