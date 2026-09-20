using System.Globalization;
using System.Text;

namespace Questao3;

public static class Program
{
    public static void Main()
    {
        Console.OutputEncoding = Encoding.UTF8;
        CultureInfo.CurrentCulture = CultureInfo.GetCultureInfo("pt-BR");

        var reserva = new Reserva
        {
            Id = 105,
            NomeHospede = "Mariana Costa",
            NumeroQuarto = 204,
            QuantidadeDiarias = 3,
            ValorDiaria = 189.90m,
            StatusInterno = "CONFIRMADA",
            ObservacaoInterna = "Conferir cadastro na recepção."
        };

        var relatorio = Mapear(reserva);
        ExibirRelatorio(relatorio);
    }

    public static RelatorioReservaDto Mapear(Reserva reserva)
    {
        ArgumentNullException.ThrowIfNull(reserva);

        return new RelatorioReservaDto(
            reserva.NomeHospede,
            reserva.NumeroQuarto,
            reserva.QuantidadeDiarias,
            reserva.QuantidadeDiarias * reserva.ValorDiaria,
            "Reserva confirmada");
    }

    public static void ExibirRelatorio(RelatorioReservaDto relatorio)
    {
        ArgumentNullException.ThrowIfNull(relatorio);

        Console.WriteLine($"Hóspede: {relatorio.NomeHospede}");
        Console.WriteLine($"Quarto: {relatorio.NumeroQuarto}");
        Console.WriteLine($"Quantidade de diárias: {relatorio.QuantidadeDiarias}");
        Console.WriteLine($"Valor total: {relatorio.ValorTotal:C2}");
        Console.WriteLine($"Situação: {relatorio.Situacao}");
    }
}
