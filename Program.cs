using DIO.Series.Classes;
using System;

namespace DIO.Series.Enum
{
    public class Program
    {
        static SerieRepositorio repositorio = new SerieRepositorio();

        static void Main(string[] args)
        {
            string opcaoUsuario;
            do
            {
                opcaoUsuario = ObterOpcaoUsuario();
                switch (opcaoUsuario)
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
                        break;
                    case "X":
                        break;
                    default:
                        break;
                }
            } while (opcaoUsuario != "X");
        }

        private static void ListarSeries()
        {
            var lista = repositorio.Lista();
            if (lista.Count > 0)
            {
                Console.WriteLine();
                foreach (var serie in lista)
                {
                    Console.Write($"#ID {serie.GetId()} - {serie.GetTitulo()}");
                    if (serie.GetExcluido()) Console.Write(" *Excluído*\n");
                    else Console.Write("\n");
                }
                Console.WriteLine();
            } else
            {
                Console.WriteLine("\nNenhuma série cadastrada.\n");
            }
        }

        private static void InserirSerie()
        {
            Console.WriteLine("\nInserir nova série:\n");

            foreach (int i in System.Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("\t{0}-{1}", i, System.Enum.GetName(typeof(Genero), i));
            }
            Console.WriteLine();

            Console.Write("Digite o gênero dentre as opções acima: ");
            int entradaGenero = int.Parse(Console.ReadLine());

            Console.Write("Digite o título da série: ");
            string entradaTitulo = Console.ReadLine();

            Console.Write("Digite o ano de início da série: ");
            int entradaAno = int.Parse(Console.ReadLine());

            Console.Write("Digite a descrição da série: ");
            string entradaDescricao = Console.ReadLine();

            Console.WriteLine();

            repositorio.Insere(new Serie(
                repositorio.ProximoId(),
                (Genero) entradaGenero,
                entradaTitulo,
                entradaDescricao,
                entradaAno
            ));
        }
        private static void AtualizarSerie()
        {
            Console.WriteLine("\nAtualizar série existente:\n");

            Console.Write("Digite o id da série: ");
            int entradaId = int.Parse(Console.ReadLine());

            var lista = repositorio.Lista();

            if (entradaId > lista.Count)
            {
                Console.WriteLine("O id inserido é inválido.\n");
                return;
            }

            foreach (int i in System.Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("\t{0}-{1}", i, System.Enum.GetName(typeof(Genero), i));
            }
            Console.WriteLine();

            Console.Write("Digite o gênero dentre as opções acima: ");
            int entradaGenero = int.Parse(Console.ReadLine());

            Console.Write("Digite o título da série: ");
            string entradaTitulo = Console.ReadLine();

            Console.Write("Digite o ano de início da série: ");
            int entradaAno = int.Parse(Console.ReadLine());

            Console.Write("Digite a descrição da série: ");
            string entradaDescricao = Console.ReadLine();

            Console.WriteLine();

            repositorio.Atualiza(entradaId, new Serie(
                entradaId,
                (Genero)entradaGenero,
                entradaTitulo,
                entradaDescricao,
                entradaAno
            ));
        }
        private static void ExcluirSerie()
        {
            Console.Write("Digite o id da série: ");
            int entradaId = int.Parse(Console.ReadLine());

            repositorio.Exclui(entradaId);
        }

        private static void VisualizarSerie()
        {
            Console.Write("Digite o id da série: ");
            int entradaId = int.Parse(Console.ReadLine());

            Console.WriteLine(repositorio.RetornaPorId(entradaId));
        }

        private static string ObterOpcaoUsuario()
        {
            Console.WriteLine("DIO Séries ao seu dispor");
            Console.WriteLine("Informe a opção desejada:\n");
            Console.WriteLine("\t1 - Listar séries;");
            Console.WriteLine("\t2 - Inserir nova série;");
            Console.WriteLine("\t3 - Atualizar série;");
            Console.WriteLine("\t4 - Excluir série;");
            Console.WriteLine("\t5 - Visualizar série;");;
            Console.WriteLine("\tC - Limpar tela;");
            Console.WriteLine("\tX - Sair.\n");

            Console.Write("Digite sua escolha: ");
            string opcaoUsuario = Console.ReadLine().ToUpper();
            return opcaoUsuario;
        }
    }
}
