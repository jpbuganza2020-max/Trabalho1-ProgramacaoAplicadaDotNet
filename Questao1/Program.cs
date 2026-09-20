using System.Text;

namespace Questao1;

public static class Program
{
    public static void Main()
    {
        Console.OutputEncoding = Encoding.UTF8;

        object?[] usuarios =
        [
            new Aluno
            {
                Nome = "Ana",
                Matricula = "A2026001",
                QuantidadeEmprestimosAtivos = 2
            },
            new Aluno
            {
                Nome = "Bruno",
                Matricula = "A2026002",
                QuantidadeEmprestimosAtivos = 3
            },
            new Professor
            {
                Nome = "Carla",
                Departamento = "Tecnologia da Informação",
                QuantidadeEmprestimosAtivos = 4
            },
            new Professor
            {
                Nome = "Daniel",
                Departamento = "Engenharia",
                QuantidadeEmprestimosAtivos = 5
            },
            new Visitante
            {
                Nome = "Elisa",
                Documento = "VIS-001",
                QuantidadeEmprestimosAtivos = 0
            },
            null,
            new UsuarioBiblioteca { Nome = "Felipe" }
        ];

        foreach (var usuario in usuarios)
        {
            var nome = (usuario as UsuarioBiblioteca)?.Nome ?? "Sem usuário";
            Console.WriteLine($"{nome}: {VerificarEmprestimo(usuario)}");
        }
    }

    public static string VerificarEmprestimo(object? obj) => obj switch
    {
        null => "Usuário inválido",
        Aluno { QuantidadeEmprestimosAtivos: < 3 } => "Empréstimo autorizado para aluno",
        Aluno { QuantidadeEmprestimosAtivos: >= 3 } => "Limite de empréstimos atingido para aluno",
        Professor { QuantidadeEmprestimosAtivos: < 5 } => "Empréstimo autorizado para professor",
        Professor { QuantidadeEmprestimosAtivos: >= 5 } => "Limite de empréstimos atingido para professor",
        Visitante => "Visitantes não podem realizar empréstimos",
        _ => "Usuário não classificado"
    };
}
