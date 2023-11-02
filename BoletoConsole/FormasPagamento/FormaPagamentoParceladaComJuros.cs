using BoletoConsole.Interfaces;

namespace BoletoConsole.FormasPagamento;

// Extendendo abstrações
public abstract class FormaPagamentoParceladaComJuros : FormaPagamentoParcelada, IJuros
{
    public double TaxaJuros { get; set; } = 0.1;
    public double ValorJuros(double valor) => valor * TaxaJuros;
    public double ValorTotal(double valor) => valor + ValorJuros(valor);
    public override double ValorParcelas(double valor) => ValorTotal(valor) / Parcelas;
}
