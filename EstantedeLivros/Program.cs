using System;
using System.ComponentModel.Design;
using EstantedeLivros;
using static System.Reflection.Metadata.BlobBuilder;

internal class Program
{
    private static void Main(string[] args)
    {
        int escolha;
        string escolha2;
        string nomeemprestado;
        List<Books> lista = new List<Books>();
        List<Books> listaemprestar = new List<Books>();

        do
        {
            escolha = Menu();

            switch (escolha)
            {

                case 1:
                    Books books = CadastrarLivro();
                    lista.Add(books);
                    EscreverArquivo(books);
                    break;

                case 2:

                    Console.Write("\nInforme o nome do livro para empréstimo: ");
                    escolha2 = Console.ReadLine();
                    listaemprestar.Add(EscreverArquivoEmprestimoLista(lista, escolha2));
                    foreach(var item in listaemprestar)
                    {
                        Console.WriteLine(item);
                    }
                    //lista.Remove(DeletarLivroLista(lista, escolha2));
                    break;

                /*case 3:
                    LerLivro();
                    break;*/

                case 4:
                    var texto2 = LerArquivo("cadastrolivro.txt");
                    Console.WriteLine(texto2);
                    break;

                case 5:
                    EscreverArquivoEmprestimo(listaemprestar);
                    /*string texto3 = LerArquivo("cadastroemprestimo.txt");
                    Console.WriteLine(texto3);*/
                    break;
            }

        } while (true);

        int Menu()
        {

            int escolhamenu;

            Console.WriteLine("**BEM-VINDO A ESTANTE VIRTUAL!**");

            Console.WriteLine("\n1 - Cadastrar Livro" + "\n2 - Emprestar Livro" +
                "\n3 - Ler Livro" + "\n4 - Lista de Livros" + "\n5 - Lista de Livros Emprestados");

            Console.Write("\nEscolha a opção desejada: ");
            escolhamenu = int.Parse(Console.ReadLine());

            return escolhamenu;

        } // ok

        Books CadastrarLivro()
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
        } // ok

        void EscreverArquivo(Books books)
        {
            try
            {
                if (File.Exists("cadastrolivro.txt"))
                {
                    var temp = LerArquivo("cadastrolivro.txt");
                    StreamWriter sw = new StreamWriter("cadastrolivro.txt");
                    sw.WriteLine(temp + books.ToString());
                    sw.Close();
                }
                else
                {
                    StreamWriter sw = new("cadastrolivro.txt");
                    sw.WriteLine(books.ToString());
                    sw.Close();
                }
            }
            catch (Exception)
            {
                Console.WriteLine("ERRO: Não foi possível incluír o livro!");
            }
            finally
            {
                Console.WriteLine("Livro gravado com sucesso!");
                Thread.Sleep(1000);
                Console.WriteLine();
            }
        } // ok

        string LerArquivo(string f)
        {

            string text = "";
            try
            {
                StreamReader sr = new StreamReader(f);
                text = sr.ReadToEnd();
                sr.Close();

            }
            catch (Exception e)
            {
                Console.WriteLine("Lista vazia!");
            }
            /*finally
            {
                sr.Close();
            }*/
            return text;


        } // ok





        Books EscreverArquivoEmprestimoLista(List<Books> l, string s)
        {


            foreach (var item in l)
            {
                if (item.Name.Equals(escolha2))
                {
                    return item;

                }

            }
            Console.WriteLine("Livro não encontrado!");
            return null;
        }

        void EscreverArquivoEmprestimo(List<Books>l)
        {
            try
            {
                if (File.Exists("cadastroemprestimo.txt"))
                {
                    var temp = LerArquivo("cadastroemprestimo.txt");
                    StreamWriter sw = new StreamWriter("cadastroemprestimo.txt");
                    sw.WriteLine(temp + l.ToString());
                    sw.Close();
                }
                else
                {
                    StreamWriter sw = new("cadastroemprestimo.txt");
                    
                   foreach (var item in l)
                    {
                        sw.WriteLine(item);
                    }
                    //sw.WriteLine(l.ToString());
                    sw.Close();
                }
            }
            catch (Exception)
            {
                Console.WriteLine("ERRO: Não foi possível incluír o livro!");
            }
            finally
            {
                Console.WriteLine("Livro gravado com sucesso!");
                Thread.Sleep(1000);
                Console.WriteLine();
            }
        } // ok



        /*void EscreverEmprestarLivro(string txt, string s)
        {
            try
            {
                if (File.Exists("cadastrolivro.txt"))
                {
                    var temp = LerArquivo("cadastrolivro.txt");
                    StreamWriter sw = new StreamWriter("cadastrolivro.txt");

                    if (temp.Contains(s)){
                        ;
                    }
                    sw.WriteLine(temp + books.ToString());
                    sw.Close();
                }
                else
                {
                    StreamWriter sw = new("cadastrolivro.txt");
                    sw.WriteLine(books.ToString());
                    sw.Close();
                }
            }
            catch (Exception)
            {
                Console.WriteLine("ERRO: Não foi possível incluír o livro!");
            }
            finally
            {
                Console.WriteLine("Livro gravado com sucesso!");
                Thread.Sleep(1000);
                Console.WriteLine();
            }
        }
    }*/

        Books DeletarLivroLista(List<Books> l, string s)
        {
            foreach (var item in l)
            {
                if (item.Name.Equals(s))
                {
                    return item;
                }
                else
                {
                    Console.WriteLine("\nLivro não encontrado!");
                }

            }
            return null;

            /*StreamReader sr = new StreamReader(s);

            for(int i = 0; i<s.Length; i++)
            {
                sr.ReadLine();
            }
            return null;
        }*/
        }



    }
}