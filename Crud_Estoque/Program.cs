using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using Mysqlx.Prepare;

namespace Crud_Estoque
{
    internal class Program
    {

        public class produto
        {
            public string nome { get; set; }
            public int quantidade {  get; set; }
            public double preco { get; set; }
            public string categoria {  get; set; } 
        }

        static string conexao = "Server=127.0.0.1;Port=3306;Database=estoque;Uid=root;Pwd='';";

        static void Main(string[] args)
        {
            int opcao = 0;
            int id_produto;
            int opcao2 = 0;
            
            produto p = new produto();

            do{
                Console.Clear();

                Console.WriteLine("===========================");
                Console.WriteLine("| Estoque Sakamato Market |");
                Console.WriteLine("===========================");
                Console.WriteLine("| 1. Adicionar Produto    |");
                Console.WriteLine("| 2. Atualizar Produto    |");
                Console.WriteLine("| 3. Remover Produto      |");
                Console.WriteLine("| 4. Buscar Produto       |");
                Console.WriteLine("| 5. Sair                 |");
                Console.WriteLine("===========================");

                Console.WriteLine();
                Console.Write("Escolha uma das opções acima: ");
                opcao = int.Parse(Console.ReadLine());

                switch (opcao)
                {
                    case 1:
                        Console.Clear();

                        Console.WriteLine("======================");
                        Console.WriteLine("| Adicionar Produtos |");
                        Console.WriteLine("======================");
                        Console.WriteLine();

                        Console.Write("Insira o Nome do produto: ");
                        p.nome = Console.ReadLine();

                        Console.Write("Insira a Quantidade do Produto: ");
                        p.quantidade= int.Parse(Console.ReadLine());

                        Console.Write("Insira o Preço do Produto: ");
                        p.preco = double.Parse(Console.ReadLine());

                        Console.WriteLine("Insira a categoria do Produto: ");
                        p.categoria = Console.ReadLine();

                        inserirdados(p);

                        break;

                    case 2:
                        break;
                    case 3:
                        Console.Clear();
                        Console.WriteLine("==================");
                        Console.WriteLine("| Apagar Produto |");
                        Console.WriteLine("==================");

                        Console.WriteLine();
                        Console.Write("Insira o id do produto que deseja remover: ");
                        id_produto = int.Parse(Console.ReadLine());

                        excluirprodutos(id_produto);

                        Console.WriteLine("Pressione qualquer tecla para continuar...");
                        Console.ReadKey(true);

                        break;
                    case 4:
                        Console.WriteLine("===================");
                        Console.WriteLine("| Opções de Busca |");
                        Console.WriteLine("===================");
                        Console.WriteLine("| 1. Categoria    |");
                        Console.WriteLine("| 2. Nome         |");
                        Console.WriteLine("| 3. Sair         |");
                        Console.WriteLine("===================");

                        Console.Write("Escolha uma das opções acima: ");
                        opcao2 = int.Parse(Console.ReadLine());



                        switch (opcao2)
                        {
                            case 1:

                                break;
                        }

                        break;
                }

            } while (opcao !=5); 
        }

        static public void inserirdados(produto p)
        {
            try
            {
                using (MySqlConnection con = new MySqlConnection(conexao))
                {
                    con.Open();
                    string insert = @" insert into produto (nome, quantidade, preco, categoria) values (@nome, @quantidade, @preco, @categoria) ;";

                    MySqlCommand cmd = new MySqlCommand(insert, con);
                    cmd.Parameters.AddWithValue(@"nome", p.nome);
                    cmd.Parameters.AddWithValue(@"quantidade", p.quantidade);
                    cmd.Parameters.AddWithValue(@"preco", p.preco);
                    cmd.Parameters.AddWithValue(@"categoria", p.categoria);

                    cmd.ExecuteNonQuery();
                    con.Close();
                }

            } catch(Exception ex)
            {
                Console.WriteLine($"Erro: {ex.Message}");
            }
        }

        static public void excluirprodutos(int id)
        {
            try
            {
                using (MySqlConnection con = new MySqlConnection(conexao))
                {
                    con.Open();

                    string delete = $@"delete  from produto where id_produto ={id};";

                    MySqlCommand cmd = new MySqlCommand(delete, con);
                    cmd.ExecuteNonQuery();
                    Console.WriteLine("Produto Apagado Com Sucesso!");
                    con.Close();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro: {ex.Message}");
            }
        }
    }
}
