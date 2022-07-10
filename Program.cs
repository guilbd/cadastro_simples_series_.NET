using Dio.Series.Classes;
using Dio.Series.Enum;

internal class Program
{
  static SerieRepositorio repositorio = new SerieRepositorio();
  private static void Main(string[] args)
  {
    string opcaoUsuario = ObterOpcaoUsuario();

    while (opcaoUsuario.ToUpper() != "X")
    {
      switch (opcaoUsuario)
      {
        case "1":
          ListarSeries();
          break;
        case "2":
          AdicionarSeries();
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
          Console.WriteLine("Opção inválida!");
          break;
      }

      opcaoUsuario = ObterOpcaoUsuario();

    }

    static void AdicionarSeries()
    {
      System.Console.WriteLine("Inserir nova série:");
      System.Console.WriteLine();
      foreach (int i in Enum.GetValues(typeof(Genero)))
      {
        Console.WriteLine($"{i} - {Enum.GetName(typeof(Genero), i)}");
      }

      System.Console.WriteLine("Digite o gênero da série:");
      int entradaGenero = int.Parse(Console.ReadLine());

      System.Console.WriteLine("Digite o título da série:");
      string entradaTitulo = Console.ReadLine();

      System.Console.WriteLine("Digite a descrição da série:");
      string entradaDescricao = Console.ReadLine();

      System.Console.WriteLine("Digite o ano da série:");
      int entradaAno = int.Parse(Console.ReadLine());

      Series novaSerie = new Series(
        id: repositorio.ProximoId(),
        genero: (Genero)entradaGenero,
        titulo: entradaTitulo,
        descricao: entradaDescricao,
        ano: entradaAno
      );

      repositorio.Adiciona(novaSerie);
    }

    static void ListarSeries()
    {
      var lista = repositorio.Lista();

      if (lista.Count == 0)
      {
        Console.WriteLine("Não há series cadastradas!");
        return;
      }

      foreach (var serie in lista)
      {
        var excluido = serie.retornaExcluir();
        Console.WriteLine ("#ID: {0}: - Título: {1} - {2}", serie.retornaId(), serie.retornaTitulo(), (excluido ? "*Excluída*" : "Ativa"));
      }
    }

    static string ObterOpcaoUsuario()
    {
      Console.WriteLine("Digite a opção desejada:");
      Console.WriteLine();
      Console.WriteLine("1 - Lista séries");
      Console.WriteLine("2 - Adicionar nova série");
      Console.WriteLine("3 - Atualizar série");
      Console.WriteLine("4 - Remover série");
      Console.WriteLine("5 - Visualizar série");
      Console.WriteLine("C - Limpar tela");
      Console.WriteLine("X - Sair");
      Console.WriteLine();
      string opcaoUsuario = Console.ReadLine().ToUpper();
      Console.WriteLine();
      return opcaoUsuario;
    }
  }

  private static void VisualizarSerie()
  {
    System.Console.WriteLine("Digite o id da série: ");
    int id = int.Parse(Console.ReadLine());
    var serie = repositorio.RetornaPorId(id);
    System.Console.WriteLine(serie);
  }

  private static void ExcluirSerie()
  {
    System.Console.WriteLine("Digite o id da série: ");
    int id = int.Parse(Console.ReadLine());

    repositorio.Remove(id);
    
  }

  private static void AtualizarSerie()
  {
    Console.WriteLine("Digite o ID da série que deseja atualizar:");
    int id = int.Parse(Console.ReadLine());
    var serie = repositorio.RetornaPorId(id);
    if (serie == null)
    {
      Console.WriteLine("Série não encontrada!");
      return;
    }
    Console.WriteLine("Digite o gênero da série:");
    int entradaGenero = int.Parse(Console.ReadLine());
    Console.WriteLine("Digite o título da série:");
    string entradaTitulo = Console.ReadLine();
    Console.WriteLine("Digite a descrição da série:");
    string entradaDescricao = Console.ReadLine();
    Console.WriteLine("Digite o ano da série:");
    int entradaAno = int.Parse(Console.ReadLine());
    Series atualizaSerie = new Series(
      id: id,
      genero: (Genero)entradaGenero,
      titulo: entradaTitulo,
      descricao: entradaDescricao,
      ano: entradaAno
    );

    repositorio.Atualiza(id, atualizaSerie);
  }
}
