using System;
using System.Collections.Generic;

namespace DIO.Series
{
    class Program
    {
        static SerieRepositorio repoSerie = new SerieRepositorio();
        static FilmeRepositorio repoFilme = new FilmeRepositorio();
        static void Main(string[] args)
        {   
            string opcaoUsuario = ObterOpcaoUsuario();
            while (opcaoUsuario.ToUpper() != "X")
            {
                switch (opcaoUsuario)
                {
                    case "1":
                        Inserir();
                        break;
                    case "2":
                        Listar();
                        break;
                    case "3":
                        Atualizar();
                        break;
                    case "4":
                        Excluir();
                        break;
                    case "5":
                        Visualizar();
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

        private static void MostrarConteudo(int tipo = 1)
        {   
            Console.WriteLine($"------------------- {(tipo == 1 ? "Filmes" : "Séries")} -------------------");
            if (tipo == 1)
            {
                foreach (var filme in repoFilme.Lista())
                {
                    bool excluidoFilme = filme.retornaExcluido();
                    if (!excluidoFilme)
                        Console.WriteLine("#ID {0}: - {1} ({2})", filme.retornoId(), filme.retornoTitulo(), filme.retornoAno());
                }
            } else {
                foreach (var serie in repoSerie.Lista())
                {
                    bool excluidoSerie = serie.retornaExcluido();
                    if (!excluidoSerie)
                        Console.WriteLine("#ID {0}: - {1} ({2})", serie.retornoId(), serie.retornoTitulo(), serie.retornoData());
                }
            }
        }
        private static Dictionary<string, string> AdicionarConteudo(bool atualizar = false, string tipo = "1")
        {
            Dictionary<string, string>  dict = new Dictionary<string, string> ();

             dict["tipo"] = tipo;
            if (!atualizar)
            {
                Console.Write("\t1 - Filme\n\t2 - Série\nResposta: ");
                dict["tipo"] = Console.ReadLine();
            }

            Console.WriteLine("Gênero");
            foreach(int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("\t{0} - {1}", i, Enum.GetName(typeof(Genero),i));
            }
            Console.Write("Selecione uma opção: ");
            dict["genero"] = Console.ReadLine();

            Console.Write($"Digite o Título: ");
            dict["titulo"] = Console.ReadLine();


            if (int.Parse(dict["tipo"]) == 1) {
                Console.Write("Ano de Lançamento: ");
                dict["anoLancamento"] = Console.ReadLine();
            } 
            else 
            {
               Console.Write("Ano de Início: ");
                dict["anoInicio"] = Console.ReadLine();

                Console.Write("Ano Final: ");
                dict["anoFinal"] = Console.ReadLine();     
            }

            Console.Write("Descricao: ");
            dict["descricao"] = Console.ReadLine();

            return dict;
        }

        private static void Excluir()
        {   
            Console.WriteLine($"---------- Excluir ----------");
            Console.Write("\t1 - Filme\n\t2 - Série\nResposta: ");
            int selecao = int.Parse(Console.ReadLine());

            Console.Write("ID: ");
            int indicieSerie = int.Parse(Console.ReadLine()); 
            

            if (selecao == 1) 
            {
                Console.Write($"Tem certeza que deseja exclir o Filme: \n{repoFilme.RetornaPorId(indicieSerie).retornoTitulo()}? \n(S/N): ");
                string querExcluir = Console.ReadLine();
                if (querExcluir.ToUpper() == "S")
                    repoSerie.Exclui(indicieSerie);
            }
            else
            {
                Console.Write($"Tem certeza que deseja exclir a Série: \n{repoSerie.RetornaPorId(indicieSerie).retornoTitulo()}? \n(S/N): ");
                string querExcluir = Console.ReadLine();
                if (querExcluir.ToUpper() == "S")
                    repoSerie.Exclui(indicieSerie);
            }
            
        }

        private static void Visualizar()
        {
            Console.WriteLine($"---------- Vizualizar ----------");

            Console.Write("Tipo\n\t1 - Filmes\n\t2 - Série\nResposta: ");
            int selecao = int.Parse(Console.ReadLine());

            Console.Write("ID: ");
            int indicie = int.Parse(Console.ReadLine());

            if (selecao == 1)
            {
                Console.WriteLine("----------- Filme -----------");
                var filme = repoFilme.RetornaPorId(indicie);
                Console.Write(filme);
            }
            else
            {
                Console.WriteLine("----------- Série -----------");
                var serie = repoSerie.RetornaPorId(indicie);
                Console.Write(serie);
            }
            Console.WriteLine();
            Console.WriteLine("Aperte Qualquer tecla para continuar...");
            Console.ReadLine();
        }

        private static void Atualizar()
        {
            Console.WriteLine($"------------ Vizualizar ------------");

            Console.Write("Tipo\n\t1 - Filme\n\t2 - Série\nResposta: ");
            string tipo = Console.ReadLine();
            
            Console.Write("ID: ");
            int indicie = int.Parse(Console.ReadLine());

            Console.Write("Deseja Atualizar tudo? (S/N): ");
            string opcao = Console.ReadLine();
            
            if (opcao == "S")
            {
                Inserir(atualizar: true, tipo: tipo, id: indicie);
            }
            else
            {
                if (tipo == "1")
                {
                    Filme filme = repoFilme.RetornaPorId(indicie);
                    Console.Write("O Que Deseja Atualizar?\n\t1 - Gênero\n\t2 - Título\n\t3 - Descrição\n\t4 - Ano de Lançamento\nResposta: ");
                    int item = int.Parse(Console.ReadLine());

                    if (item == 1)
                    {
                        Console.WriteLine("Gênero");
                        foreach(int i in Enum.GetValues(typeof(Genero)))
                        {
                            Console.WriteLine("\t{0} - {1}", i, Enum.GetName(typeof(Genero),i));
                        }
                    }

                    Console.Write("Novo valor: ");

                    Console.Write("Novo valor: ");
                    string valor = Console.ReadLine();

                    filme.AtualizarPorItem(item, valor);
                }
                else 
                {
                    Serie serie = repoSerie.RetornaPorId(indicie);
                    Console.Write("O Que Deseja Atualizar?\n\t1 - Gênero\n\t2 - Título\n\t3 - Descrição\n\t4 - Ano de Iníco\n\t5 - Ano Final\nResposta: ");
                    int item = int.Parse(Console.ReadLine());

                    if (item == 1)
                    {
                        Console.WriteLine("Gênero");
                        foreach(int i in Enum.GetValues(typeof(Genero)))
                        {
                            Console.WriteLine("\t{0} - {1}", i, Enum.GetName(typeof(Genero),i));
                        }
                    }

                    Console.Write("Novo valor: ");
                    string valor = Console.ReadLine();
                    serie.AtualizarPorItem(item, valor);
                }
            }
        }

        private static void Inserir(bool atualizar = false, string tipo = "1", int id = 0)
        {
            Console.WriteLine($"--------------------- {(atualizar ? "Atualizar" : "Inserir Novo" )} ---------------------");
            Dictionary<string, string> res = AdicionarConteudo(atualizar, tipo);
            if (int.Parse(res["tipo"]) == 1)
            {
                Filme novoFilme = new Filme(
                    id: atualizar ? id : repoFilme.ProximoId(),
                    genero: (Genero)int.Parse(res["genero"]),
                    titulo: res["titulo"],
                    descricao: res["descricao"],
                    AnoLancamento: int.Parse(res["anoLancamento"])
                );
                if (atualizar) repoFilme.Atualiza(id, novoFilme);
                else repoFilme.Insere(novoFilme);
            }
            else
            {   
                Serie novaSerie = new Serie(
                id: atualizar ? id : repoSerie.ProximoId(),
                genero: (Genero)int.Parse(res["genero"]),
                titulo: res["titulo"],
                descricao: res["descricao"],
                anoInicio: int.Parse(res["anoInicio"]),
                anoFinal: res["anoFinal"]
                );
                if (atualizar) repoSerie.Atualiza(id, novaSerie);
                else repoSerie.Insere(novaSerie);
            }

        }

        private static void Listar()
        {   
            var listaSerie = repoSerie.Lista();
            var listaFilme = repoFilme.Lista();

            Console.WriteLine("\t\t\t----------- Listar de Filmes e Séries -----------");

            if (listaSerie.Count == 0 && listaFilme.Count == 0)
            {
                Console.WriteLine("+---------------------------+");
                Console.WriteLine("| Nenhum conteúdo cadastrada. |");
                Console.WriteLine("+---------------------------+");
            } else if(listaFilme.Count == 0)
            {
                MostrarConteudo(2);
            } else if (listaSerie.Count == 0)
            {
                MostrarConteudo();
            }
            else {
                MostrarConteudo();
                Console.WriteLine();
                MostrarConteudo(2);
            }
            Console.WriteLine("Aperte qualquer tecla para continuar...");
            Console.ReadLine();

        }

        private static string ObterOpcaoUsuario()
        {
            Console.WriteLine();
            Console.WriteLine("+--------- DIO Flix ---------+");
            Console.WriteLine("| Informe a Opção desejada:  |");

            Console.WriteLine("| 1 - Inserir novo           |");
            Console.WriteLine("| 2 - Listar conteúdo        |");
            Console.WriteLine("| 3 - Atualizar conteúdo     |");
            Console.WriteLine("| 4 - Excluir conteúdo       |");
            Console.WriteLine("| 5 - Vizualizar conteúdo    |");
            Console.WriteLine("| C - Limpar Tela            |");
            Console.WriteLine("| X - Sair                   |");
            Console.WriteLine("+----------------------------+");
            
            string opcaoUsuario = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return opcaoUsuario;
        }
    }
}
