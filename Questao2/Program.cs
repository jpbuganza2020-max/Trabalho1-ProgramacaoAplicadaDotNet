using System.Globalization;
using System.Reflection;
using System.Text;

namespace Questao2;

public static class Program
{
    public static void Main()
    {
        Console.OutputEncoding = Encoding.UTF8;
        CultureInfo.CurrentCulture = CultureInfo.GetCultureInfo("pt-BR");

        var equipamento = new Equipamento
        {
            Id = 42,
            Nome = "Notebook",
            Fabricante = "Dell",
            NumeroSerie = "LAB-2026-0042",
            Valor = 4250.90m,
            Localizacao = "Laboratório de Informática 2"
        };

        Console.WriteLine("Reflection aberta");
        ExibirDadosAberto(equipamento);

        Console.WriteLine();
        Console.WriteLine("Reflection controlada");
        ExibirDadosControlado(equipamento);
    }

    public static void ExibirDadosAberto(object objeto)
    {
        ArgumentNullException.ThrowIfNull(objeto);

        foreach (var propriedade in objeto.GetType().GetProperties())
        {
            Console.WriteLine($"{propriedade.Name}: {propriedade.GetValue(objeto)}");
        }
    }

    public static void ExibirDadosControlado(object objeto)
    {
        ArgumentNullException.ThrowIfNull(objeto);

        foreach (var propriedade in objeto.GetType().GetProperties())
        {
            if (propriedade.GetCustomAttribute<ExibirAttribute>() is not null)
            {
                Console.WriteLine($"{propriedade.Name}: {propriedade.GetValue(objeto)}");
            }
        }
    }
}
