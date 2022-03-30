using System;
namespace Dio.Series 
{
    class Program 
    {
    static SerieRepositorio repositorio = new SerieRepositorio();
        static void Main(String[] args){
            // Console.WriteLine("Hello World!");
            string opcaoUsuario = ObterOpcaoUsuario();
            while( opcaoUsuario.ToUpper() != "X" ){
                switch( opcaoUsuario ){
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
            Console.WriteLine("obrigado!!");
        }

        private static string ObterOpcaoUsuario(){
            Console.WriteLine();
            Console.WriteLine("Dio a serie a seu dispor!!");
            Console.WriteLine("Informe o que Deseja:");
            Console.WriteLine("1 - Listar series");
            Console.WriteLine("2 - Inserir nova serie");
            Console.WriteLine("3 - Atualizar a serie");
            Console.WriteLine("4 - Excluir a serie");
            Console.WriteLine("5 - Visualizar a Serie");
            Console.WriteLine("C - Limpar a tela");
            Console.WriteLine("X - Sair");
            Console.WriteLine("Informe o que Deseja:");
            string opcaoUsuario = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return opcaoUsuario;

        }

        private static void ListarSeries(){
            Console.WriteLine("Listar series");
            var lista = repositorio.Lista();
            if( lista.Count == 0 ){
                Console.WriteLine("Nenhuma serie cadastrada!");
                return;
            }

            foreach( var serie in lista ){
                var excluido = serie.retornaExcluido();
                Console.WriteLine("#ID {0}: - {1} - {2}", serie.retornaId(), serie.retornaTitulo(), excluido ? "Excluido":"No Sistem");
            }
        }

        private static void InserirSerie(){
            Console.WriteLine("inserindo nova serie");
            foreach(int i in Enum.GetValues(typeof(Genero))){
                Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
            }
            Console.WriteLine("Digite o genero entre as opcoes acima: ");
            int entadaGenero = int.Parse(Console.ReadLine());

            Console.WriteLine("Informe o titulo da serie: ");
            string entadaTitulo = Console.ReadLine();

            Console.WriteLine("Informe o ano da Serie: ");
            int entadaAno= int.Parse(Console.ReadLine());
            
            
            Console.WriteLine("Informe a descrição da serie: ");
            string entadaDescricao = Console.ReadLine();


            Series novaSeries = new Series(
                id:repositorio.ProximoId(),
                genero:(Genero)entadaGenero,
                titulo:entadaTitulo,
                descricao:entadaDescricao,
                ano:entadaAno
            );

            repositorio.Insere(novaSeries);

        }

        private static void AtualizarSerie(){

            Console.WriteLine("Digite o id da serie: ");
            int indiceSerie = int.Parse(Console.ReadLine());
            foreach( int i in Enum.GetValues(typeof(Genero)) ){
                Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
            }
            Console.WriteLine("Digite o genero entre as opcoes acima: ");
            int entadaGenero = int.Parse(Console.ReadLine());

            Console.WriteLine("Informe o titulo da serie: ");
            string entadaTitulo = Console.ReadLine();

            Console.WriteLine("Informe o ano da Serie: ");
            int entadaAno = int.Parse(Console.ReadLine());


            Console.WriteLine("Informe a descrição da serie: ");
            string entadaDescricao = Console.ReadLine();

            Series atualizar = new Series(
                id: indiceSerie,
                genero: (Genero)entadaGenero,
                titulo: entadaTitulo,
                descricao: entadaDescricao,
                ano: entadaAno
            );

            repositorio.Atualizar(indiceSerie, atualizar);

        }
        private static void ExcluirSerie(){
            Console.WriteLine("Digite o id da serie que vai ser excluida: ");
            int indiceSerie = int.Parse(Console.ReadLine());
            repositorio.Excluir(indiceSerie);
        }
        private static void VisualizarSerie(){
            Console.WriteLine("Digite o id da serie que você quer visualizar: ");
            int indiceSerie = int.Parse(Console.ReadLine());
            var serie = repositorio.RetornoPorId(indiceSerie);
            Console.WriteLine(serie);            
        }

    }
}
