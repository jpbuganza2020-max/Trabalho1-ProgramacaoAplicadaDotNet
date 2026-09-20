# Trabalho 1 - Programação Aplicada em .NET

UNIP - Análise e Desenvolvimento de Sistemas  
Professor: Me. Lucas Teodoro dos Santos

Três aplicações Console em C# e .NET 8, uma para cada questão do trabalho.

## Estrutura

```text
Trabalho1-ProgramacaoAplicadaDotNet/
├── Questao1/   # Pattern Matching: empréstimos em uma biblioteca
├── Questao2/   # Reflection aberta e controlada
├── Questao3/   # DTO e mapeamento de uma reserva de hotel
└── Trabalho1.sln
```

## Executar

É necessário ter o SDK do .NET 8 ou um SDK posterior compatível e o runtime do .NET 8 instalados. Os projetos não dependem de pacotes NuGet externos.

Na pasta do repositório:

```bash
dotnet build Trabalho1.sln
dotnet run --project Questao1
dotnet run --project Questao2
dotnet run --project Questao3
```

Também é possível abrir `Trabalho1.sln` no Visual Studio e selecionar a questão desejada como projeto de inicialização.

## Questão 1

`UsuarioBiblioteca` reúne os dados comuns de `Aluno`, `Professor` e `Visitante`. O método `VerificarEmprestimo` usa uma switch expression com padrões de tipo, propriedade, relacionais, `null` e descarte (`_`). O parâmetro aceita `null`, indicado pela anotação `object?`.

O `Main()` demonstra os sete resultados previstos, incluindo os limites de 3 empréstimos para alunos e 5 para professores:

```text
Ana: Empréstimo autorizado para aluno
Bruno: Limite de empréstimos atingido para aluno
Carla: Empréstimo autorizado para professor
Daniel: Limite de empréstimos atingido para professor
Elisa: Visitantes não podem realizar empréstimos
Sem usuário: Usuário inválido
Felipe: Usuário não classificado
```

## Questão 2

`ExibirDadosAberto` percorre todas as propriedades públicas de `Equipamento`. `ExibirDadosControlado` consulta `ExibirAttribute` para exibir apenas as propriedades marcadas com `[Exibir]`.

```text
Reflection aberta
Id: 42
Nome: Notebook
Fabricante: Dell
NumeroSerie: LAB-2026-0042
Valor: 4250,90
Localizacao: Laboratório de Informática 2

Reflection controlada
Nome: Notebook
Fabricante: Dell
Valor: 4250,90
Localizacao: Laboratório de Informática 2
```

## Questão 3

`Mapear` transforma a entidade `Reserva` no record `RelatorioReservaDto`. O total usa `decimal` e resulta de `QuantidadeDiarias * ValorDiaria`. A situação do relatório é sempre `Reserva confirmada`, conforme o enunciado.

O DTO contém somente `NomeHospede`, `NumeroQuarto`, `QuantidadeDiarias`, `ValorTotal` e `Situacao`. `Id`, `ValorDiaria`, `StatusInterno` e `ObservacaoInterna` permanecem na entidade.

```text
Hóspede: Mariana Costa
Quarto: 204
Quantidade de diárias: 3
Valor total: R$ 569,70
Situação: Reserva confirmada
```
