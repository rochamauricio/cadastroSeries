using System;

namespace Series {
  class Program {

    static SerieRepositorio repositorio = new SerieRepositorio();
    static void Main(string[] args) {
      string opcaoUsuario = ObterOpcaoUsuario();
      while (opcaoUsuario.ToUpper() != "X") {
        switch (opcaoUsuario) {
          case "1":
            ListarSeries();
            break;
          case "2":
            InserirSerie();
            break;
          case "3":
            AtualizarSerie();
            break;
          case "4":
            ExcluirSerie();
            break;
          case "5":
            VisualizarSerie();
            break;
          case "C":
            Console.Clear();
            break;
          default:
            throw new ArgumentOutOfRangeException();
        }
        opcaoUsuario = ObterOpcaoUsuario();
      }
    }

    private static void InserirSerie() {
      Console.WriteLine("Inserir nova serie:");

      foreach (int i in Enum.GetValues(typeof(Genero))) {
        Console.WriteLine("{0}.{1}", i, Enum.GetName(typeof(Genero), i));
      }

      Console.WriteLine("Digite o Genero da Série");
      int entradaGenero = int.Parse(Console.ReadLine());

      Console.Write("Digite o Título da Série: ");
      string entradaTitulo = Console.ReadLine();

      Console.Write("Digite o Ano de Início da Série: ");
      int entradaAno = int.Parse(Console.ReadLine());

      Console.Write("Digite a Descrição da Série: ");
      string entradaDescricao = Console.ReadLine();

      Serie novaSerie = new Serie(id: repositorio.ProximoId(),
                    genero: (Genero)entradaGenero,
                    titulo: entradaTitulo,
                    ano: entradaAno,
                    descricao: entradaDescricao);

      repositorio.Insere(novaSerie);
    }

    private static void ListarSeries() {
      Console.WriteLine("Listar series:");
      var lista = repositorio.Lista();

      if (lista.Count == 0) {
        Console.WriteLine("Nenhuma série cadastrada.");
        return;
      }

      foreach (var serie in lista) {
        Console.WriteLine("#ID {0}: - {1}", serie.retornaId(), serie.retornaTitulo());
      }
    }

    private static void AtualizarSerie() {
      Console.Write("Digite o ID da série: ");
      int indiceSerie = int.Parse(Console.ReadLine());

      foreach (int i in Enum.GetValues(typeof(Genero))) {
        Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
      }

      Console.Write("Digite o gênero entre as opções acima: ");
      int entradaGenero = int.Parse(Console.ReadLine());

      Console.Write("Digite o Título da Série: ");
      string entradaTitulo = Console.ReadLine();

      Console.Write("Digite o Ano de Início da Série: ");
      int entradaAno = int.Parse(Console.ReadLine());

      Console.Write("Digite a Descrição da Série: ");
      string entradaDescricao = Console.ReadLine();

      Serie atualizaSerie = new Serie(id: indiceSerie,
                    genero: (Genero)entradaGenero,
                    titulo: entradaTitulo,
                    ano: entradaAno,
                    descricao: entradaDescricao);

      repositorio.Atualiza(indiceSerie, atualizaSerie);
    }

    private static void ExcluirSerie() {
      Console.Write("Digite o ID da série: ");
      int indiceSerie = int.Parse(Console.ReadLine());

      repositorio.Exclui(indiceSerie);
    }

    private static void VisualizarSerie() {
      Console.Write("Digite o ID da série: ");
      int indiceSerie = int.Parse(Console.ReadLine());

      var serie = repositorio.RetornaPorId(indiceSerie);
      Console.WriteLine(serie);
    }

    private static string ObterOpcaoUsuario() {
      Console.WriteLine();
      Console.WriteLine("Informe a opção desejada:");
      Console.WriteLine("1 - Listar series");
      Console.WriteLine("2 - Inserir nova serie");
      Console.WriteLine("3 - Atualizar serie");
      Console.WriteLine("4 - Excluir serie");
      Console.WriteLine("5 - Visualizar serie");
      Console.WriteLine("C - Limpar tela");
      Console.WriteLine("X - SAIR");
      Console.WriteLine();

      string opcaoUsuario = Console.ReadLine().ToUpper();
      Console.WriteLine();
      return opcaoUsuario;
    }
  }
}
