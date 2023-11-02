using BoletoConsole.FormasPagamento;
using BoletoConsole.Interfaces;
using System.Reflection;

namespace Pagamento;

public static class Exemplo
{
    public static void Main()
    {


        // Criando um boleto
        Boleto boletoObj = new Boleto(1); // podemos acessar boletoObj.CodigoBoleto;
        //boletoObj.Pagar(100);

        FormaPagamento boletoFormaPagamento = new Boleto(2); // não podemos acessar boletoObj.CodigoBoleto;
        //boletoFormaPagamento.Pagar(200);

        Boleto boletoCast = (Boleto)boletoFormaPagamento; // podemos acessar boletoObj.CodigoBoleto;
        //boletoCast.Pagar(20);

        IPagamento boletoInteface = new Boleto(3);
        //boletoInteface.Pagar(300);

        Boleto boletoCastInterface = (Boleto)boletoInteface; // podemos acessar boletoObj.CodigoBoleto;
                                                             //boletoCastInterface.Pagar(20);


        //Criando um Carnê
        FormaPagamento carneLojaFormaPagamento = new CarneLoja();
        FormaPagamentoParcelada carneLojaParcelada = new CarneLoja();

        //Criando Cartao
        FormaPagamento cartaoFormaPagamento = new Cartao();
        FormaPagamentoParcelada cartaoParcelada = new Cartao();
        FormaPagamentoParceladaComJuros cartaoComJuros = new Cartao();

        //Criando processador de compra genérico
        ProcessaPagamento processaPagamentoGenerico = new ProcessaPagamento();

        //Usando processador genérico
        //processaPagamentoGenerico.ProcessarPagamento(boletoFormaPagamento, 300); // não funciona com boletoInteface
        //processaPagamentoGenerico.ProcessarPagamento(carneLojaFormaPagamento, 1000);
        //processaPagamentoGenerico.ProcessarPagamento(cartaoFormaPagamento, 500);

        //Criando processador de compra parcelado
        ProcessaPagamentoParcelado processaPagamentoParcelado = new ProcessaPagamentoParcelado();

        //Usando processador genérico
        //processaPagamentoParcelado.ProcessarPagamento(carneLojaParcelada, 300);
        //processaPagamentoParcelado.ProcessarPagamento(cartaoParcelada, 500, 10);
        //processaPagamentoParcelado.ProcessarPagamento(cartaoComJuros, 500);

        //Criando processador de compra genérico
        ProcessaPagamentoParceladoComJuros processaPagamentoParceladoComJuros = new ProcessaPagamentoParceladoComJuros();

        //Usando processador genérico
        //processaPagamentoParceladoComJuros.ProcessarPagamento(cartaoComJuros, 300);
        //processaPagamentoParceladoComJuros.ProcessarPagamento(cartaoComJuros, 300, 2);
        //processaPagamentoParceladoComJuros.ProcessarPagamento(cartaoComJuros, 300, 10, 0.8);



        // FormaPagamento x IPagamento
        IPagamento[] pagamentos = new[]
        {
            boletoObj, boletoFormaPagamento,
            boletoCast, boletoInteface,
            boletoCastInterface, carneLojaFormaPagamento,
            cartaoFormaPagamento, cartaoParcelada,
            cartaoComJuros
        };

        for (int i = 0; i < pagamentos.Length; i++)
        {
            var pagamento = pagamentos[i];

            if (i % 2 > 0)
            {
                var random = new Random();
                pagamento.Pagar(random.Next(1000)+10);
            }

            ExibirDadosDoPagamento(pagamento);
        }

    
    }

    private static void ExibirDadosDoPagamento(IPagamento pagamento)
    {
        var tipo = pagamento.GetType();
        Console.WriteLine($"Pagamento do tipo: {tipo.Name}");

        var propriedades = tipo.GetProperties(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);

        foreach (var prop in propriedades.Where(x => !x.Name.Equals("Pago")))
        {
            Console.WriteLine($"A propriedade {prop.Name} é do tipo {prop.PropertyType} e tem valor {prop.GetValue(pagamento)}");
        }

        var propriedadePago = propriedades.Where(x => x.Name.Equals("Pago")).First();
        var pago = (bool)propriedadePago.GetValue(pagamento);

        Console.WriteLine(pago? "Está pago" : "Não está pago");

        Console.WriteLine(Environment.NewLine);
    }
}