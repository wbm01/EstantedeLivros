using System.ComponentModel.Design;
using System.Globalization;
using EstantedeLivros;
using static System.Reflection.Metadata.BlobBuilder;

internal class Program
{
    private static void Main(string[] args)
    {
        int escolhamenu;
        string escolhaemprestimo;
        string escolhaleitura;
        List<Books> lista = new List<Books>();
        List<Books> listaemprestar = new List<Books>();
        List<Books> listaleitura = new List<Books>();

        do
        {
            escolhamenu = Menu();

            switch (escolhamenu)
            {

                case 1:
                    Books books = CadastrarLivro();
                    lista.Add(books);
                    CriarArquivoLivrosDisponiveis();
                    break;

                case 2:

                    Console.Write("\nInforme o nome do livro para empréstimo: ");
                    escolhaemprestimo = Console.ReadLine();
                    listaemprestar.Add(IncluirListaEmprestimo(lista, escolhaemprestimo));
                    lista.Remove(DeletarLivro());
                    CriarArquivoLivrosEmprestados();
                    CriarArquivoLivrosDisponiveis();
                    break;

                case 3:
                    Console.Write("\nInforme o nome do livro que deseja ler: ");
                    escolhaleitura = Console.ReadLine();
                    listaleitura.Add(IncluirListaLeitura(lista, listaemprestar, escolhaleitura));
                    lista.Remove(IncluirListaLeitura(lista, listaemprestar, escolhaleitura));
                    CriarArquivoLivrosLeitura();
                    CriarArquivoLivrosDisponiveis();
                    break;

                case 4:
                    //ImprimirListaLivrosDisponiveis();
                    string retorno = LerArquivo("cadastrolivro.txt");
                    Console.WriteLine(retorno);
                    break;

                case 5:
                    //ImprimirListaEmprestimo();
                    string retorno2 = LerArquivo("cadastroemprestimo.txt");
                    Console.WriteLine(retorno2);
                    break;

                case 6:
                    //ImprimirListaLeitura();
                    string retorno3 = LerArquivo("cadastrolivroleitura.txt");
                    Console.WriteLine(retorno3);
                    break;
            }

        } while (true);

        int Menu()
        {

            int escolhamenu;

            Console.WriteLine("**BEM-VINDO A ESTANTE VIRTUAL!**");

            Console.WriteLine("\n1 - Cadastrar Livro" + "\n2 - Emprestar Livro" +
                "\n3 - Ler Livro" + "\n4 - Lista de Livros disponíveis" + "\n5 - Lista de Livros Emprestados" +
                "\n6 - Lista de Livros Separados para Leitura");

            Console.Write("\nEscolha a opção desejada: ");
            escolhamenu = int.Parse(Console.ReadLine());

            return escolhamenu;

        } // ok

        Books CadastrarLivro()
        {
            try
            {
                Console.Write("\nInforme o nome do livro: ");
                string name = Console.ReadLine();

                Console.Write("\nInforme a edição: ");
                string edition = Console.ReadLine();

                Console.Write("\nInforme o autor: ");
                string writer = Console.ReadLine();

                Console.Write("\nInforme o autor 2: ");
                string writer2 = Console.ReadLine();

                Console.Write("\nInforme o ISBN: ");
                string isbn = Console.ReadLine();

                return new Books(name, edition, writer, writer2, isbn);
            }
            catch
            {
                Console.WriteLine("Não foi possível gravar!");
            }
            finally
            {
                Console.WriteLine("Livro cadastrado com sucesso!");
            }
            return null;
        } // ok

        Books IncluirListaEmprestimo(List<Books> l, string s)
        {
            try
            {
                foreach (var item in l)
                {

                    if (item.Name == s)
                    {
                        return item;
                    }
                }
            }
            catch
            {
                Console.WriteLine("Não foi possível gravar!");
            }
            finally
            {
                Console.WriteLine("Livro emprestado com sucesso!");
            }

            return null;

        }

        Books DeletarLivro()
        {
            foreach (var item in lista)
            {

                if (item.Name == escolhaemprestimo)
                {
                    return item;
                }
                else
                {
                    Console.WriteLine("Livro não encontrado!");

                }
            }
            return null;

        }

        void ImprimirListaLivrosDisponiveis()
        {
            foreach (var item in lista)
            {
                if (item == null)
                {
                    Console.WriteLine("Lista vazia!");
                }
                else
                {
                    Console.WriteLine(item);
                }
            }
        }

        void ImprimirListaEmprestimo()
        {
            foreach (var item in listaemprestar)
            {
                if (item == null)
                {
                    Console.WriteLine("Lista vazia!");
                }
                else
                {
                    Console.WriteLine(item);
                }
            }
        }

        Books IncluirListaLeitura(List<Books> l, List<Books> e, string s)
        {

            foreach (var item in l)
            {
                foreach (var item2 in e)
                {
                    if (item.Name == s)
                    {
                        Console.WriteLine("Livro separado para leitura!");
                        return item;
                    }
                    else if (item2.Name == s)
                    {
                        Console.WriteLine("Livro emprestado, não foi possível separar para leitura!");
                        return null;
                    }
                    else
                    {
                        Console.WriteLine("Livro não encontrado!");

                    }
                }
            }
            return null;
        }

        void ImprimirListaLeitura()
        {
            foreach (var item in listaleitura)
            {
                if (item == null)
                {
                    Console.WriteLine("Lista vazia!");
                }
                else
                {
                    Console.WriteLine(item);
                }
            }
        }

        void CriarArquivoLivrosDisponiveis()
        {
            try
            {
                if (File.Exists("cadastrolivro.txt"))
                {
                    var temp = LerArquivo("cadastrolivro.txt");
                    StreamWriter sw = new StreamWriter("cadastrolivro.txt");
                    for (int i = 0; i < lista.Count; i++)
                    {
                        sw.WriteLine(lista[i].ToString());
                    }
                    //Console.WriteLine(temp.ToString());

                    sw.Close();
                }
                else
                {
                    StreamWriter sw = new("cadastrolivro.txt");
                    for (int i = 0; i < lista.Count; i++)
                    {
                        sw.WriteLine(lista[i].ToString());
                    }
                    sw.Close();
                }
            }
            catch (Exception)
            {
                Console.WriteLine("ERRO: Não foi possível incluír o livro!");
            }
            finally
            {

                Thread.Sleep(1000);
                Console.WriteLine();
            }
        }

        void CriarArquivoLivrosEmprestados()
        {
            try
            {
                if (File.Exists("cadastroemprestimo.txt"))
                {
                    var temp2 = LerArquivo("cadastroemprestimo.txt");
                    StreamWriter sw = new StreamWriter("cadastroemprestimo.txt");
                    for (int i = 0; i < listaemprestar.Count; i++)
                    {

                        sw.WriteLine(listaemprestar[i].ToString());
                    }
                    //Console.WriteLine(temp2.ToString());

                    sw.Close();
                }
                else
                {
                    StreamWriter sw = new("cadastroemprestimo.txt");
                    for (int i = 0; i < listaemprestar.Count; i++)
                    {
                        sw.WriteLine(listaemprestar[i].ToString());
                    }
                    sw.Close();
                }
            }
            catch (Exception)
            {
                Console.WriteLine("ERRO: Não foi possível incluír o livro!");
            }
            finally
            {

                Thread.Sleep(1000);
                Console.WriteLine();
            }
        }

        void CriarArquivoLivrosLeitura()
        {
            try
            {
                if (File.Exists("cadastrolivroleitura.txt"))
                {
                    var temp3 = LerArquivo("cadastrolivroleitura.txt");
                    StreamWriter sw = new StreamWriter("cadastrolivroleitura.txt");
                    for (int i = 0; i < listaleitura.Count; i++)
                    {
                        sw.WriteLine(listaleitura[i].ToString());
                    }
                    //Console.WriteLine(temp3.ToString());

                    sw.Close();
                }
                else
                {
                    StreamWriter sw = new("cadastrolivroleitura.txt");
                    for (int i = 0; i < listaleitura.Count; i++)
                    {
                        sw.WriteLine(listaleitura[i].ToString());
                    }
                    sw.Close();
                }
            }
            catch (Exception)
            {
                Console.WriteLine("ERRO: Não foi possível incluír o livro!");
            }
            finally
            {

                Thread.Sleep(1000);
                Console.WriteLine();
            }
        }

        string LerArquivo(string f)
        {

            string text = "";
            try
            {
                StreamReader sr = new StreamReader(f);
                text = sr.ReadToEnd();
                sr.Close();

            }
            catch (Exception)
            {
                Console.WriteLine("Lista vazia!");
            }

            return text;
        }
    }
}
