using BoletoConsole.Interfaces;

namespace BoletoConsole.FormasPagamento;

// Extendendo abstrações
public abstract class FormaPagamentoParcelada : FormaPagamento, IParcelamento
{
    public int Parcelas { get; set; } = 1;
    public abstract double ValorParcelas(double valor);
}
