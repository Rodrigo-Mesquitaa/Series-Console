using System;
using Series.Class;
using Series.Enums;
using Series.Repositories;

namespace Series
{
    class Program
	{
		private static SerieRepository _repository = new SerieRepository();

		static void Main(string[] args)
		{
			string userChoice = GetUserChoice();

			while (userChoice.ToUpper() != "X")
			{
				switch (userChoice)
				{
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

				userChoice = GetUserChoice();
			}

			Console.WriteLine("Obrigado por utilizar nossos serviços.");
			Console.ReadLine();
		}

		private static void ExcluirSerie()
		{
			Console.Write("Digite o id da série: ");
			int indiceSerie = int.Parse(Console.ReadLine());

			_repository.Delete(indiceSerie);
		}

		private static void VisualizarSerie()
		{
			Console.Write("Digite o id da série: ");
			int indiceSerie = int.Parse(Console.ReadLine());

			var serie = _repository.FindById(indiceSerie);

			Console.WriteLine(serie);
		}

		private static void AtualizarSerie()
		{
			Console.Write("Digite o id da série: ");
			int indiceSerie = int.Parse(Console.ReadLine());

			foreach (int i in Enum.GetValues(typeof(Gender)))
			{
				Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Gender), i));
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
										gender: (Gender)entradaGenero,
										title: entradaTitulo,
										year: entradaAno,
										description: entradaDescricao);

			_repository.Update(indiceSerie, atualizaSerie);
		}
		private static void ListarSeries()
		{
			Console.WriteLine("Listar séries");

			var lista = _repository.FindAll();

			if (lista.Count == 0)
			{
				Console.WriteLine("Nenhuma série cadastrada.");
				return;
			}

			foreach (var serie in lista)
			{
				var excluido = serie.ReturnDeleted();

				Console.WriteLine("#ID {0}: - {1} {2}", serie.ReturnId(), serie.ReturnTitle(), (excluido ? "*Excluído*" : ""));
			}
		}

		private static void InserirSerie()
		{
			Console.WriteLine("Inserir nova série");

			foreach (int i in Enum.GetValues(typeof(Gender)))
			{
				Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Gender), i));
			}
			Console.Write("Digite o gênero entre as opções acima: ");
			int entradaGenero = int.Parse(Console.ReadLine());

			Console.Write("Digite o Título da Série: ");
			string entradaTitulo = Console.ReadLine();

			Console.Write("Digite o Ano de Início da Série: ");
			int entradaAno = int.Parse(Console.ReadLine());

			Console.Write("Digite a Descrição da Série: ");
			string entradaDescricao = Console.ReadLine();

			Serie novaSerie = new Serie(id: _repository.NextId(),
										gender: (Gender)entradaGenero,
										title: entradaTitulo,
										year: entradaAno,
										description: entradaDescricao);

			_repository.Create(novaSerie);
		}

		private static string GetUserChoice()
		{
			Console.WriteLine();
			Console.WriteLine("DIO Séries ao seu dispor!!!");
			Console.WriteLine("Informe a opção desejada:");

			Console.WriteLine("1 - Listar séries");
			Console.WriteLine("2 - Inserir nova série");
			Console.WriteLine("3 - Atualizar série");
			Console.WriteLine("4 - Excluir série");
			Console.WriteLine("5 - Visualizar série");
			Console.WriteLine("C - Limpar a tela");
			Console.WriteLine("X - Sair");
			Console.WriteLine();

			string userChoice = Console.ReadLine().ToUpper();
			Console.WriteLine();
			return userChoice;
		}
	}
}
