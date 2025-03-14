using System;
using System.ComponentModel;
using Microsoft.Data.Sqlite;

namespace PedidosSQLite.model
{
    public static class ProdutosDAO
    {
        private static string strConexao = @"Data Source=D:\Usuários\MatheusRodriguesViei\Documents\GitHub\GerenciadorPedidosSQLite\PedidosSQLite\database\pedidosTeste.db";

public static void cadastrarProduto()
        {
            try
            {
                using (SqliteConnection cnx = new SqliteConnection(strConexao))
                {
                    if (cnx.State == System.Data.ConnectionState.Closed)
                    {
                        cnx.Open();
                        Console.WriteLine("Conexão com o banco de dados estabelecida com sucesso.");

                        Console.WriteLine("\n--- CADASTRO DE PRODUTOS ---\nDigite o nome: ");
                        string nome = Console.ReadLine();
                        Console.WriteLine("Digite o preço: ");
                        double preco = double.Parse(Console.ReadLine());
                        int estoque = int.Parse(Console.ReadLine());
                        string sql = "INSERT INTO Produtos (nome, preco, estoque) VALUES (@nome, @preco, @estoque)";
                        using (SqliteCommand cmd = new SqliteCommand(sql, cnx))
                        {
                            cmd.Parameters.AddWithValue("@nome", nome);
                            cmd.Parameters.AddWithValue("@preco", preco);
                            cmd.Parameters.AddWithValue("@estoque", estoque);
                            cmd.ExecuteNonQuery();
                            Console.WriteLine("Produto cadastrado com sucesso.");
                        }

                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro ao conectar com o banco de dados: " + ex.Message);
            }
        }

        public static void atualizarProdutos()
        {
            try
            {
                using (SqliteConnection cnx = new SqliteConnection(strConexao))
                {
                    if (cnx.State == System.Data.ConnectionState.Closed)
                    {
                        cnx.Open();
                        Console.WriteLine("\nConexão com o banco de dados estabelecida com sucesso.");
                    }

                    //VALIDAR A ALTERAÇÃO, DESEJA ALTERAR ESTOQUE? DESEJA ALTERAR PREÇO? ETC
                    Console.WriteLine("\n--- ATUALIZAÇÃO DE PRODUTOS ---");
                    Console.Write("Digite o nome do produto: ");
                    string nome = Console.ReadLine();

                    Console.Write("Digite o novo preço: ");
                    double preco = double.Parse(Console.ReadLine());

                    Console.Write("Digite o novo email: ");
                    double preco = double.Parse(Console.ReadLine());

                    // Validação para que os campos não estejam vazios
                    if (string.IsNullOrWhiteSpace(nome) || DoubleConverter.IsNullOrWhiteSpace(preco))
                    {
                        Console.WriteLine("Erro: Nome ou preço não podem estar vazios.");
                        return;
                    }

                    string sql = "UPDATE clientes SET email = @Email WHERE nome = @Nome";
                    using (SqliteCommand cmd = new SqliteCommand(sql, cnx))
                    {
                        cmd.Parameters.AddWithValue("@Nome", nome);
                        cmd.Parameters.AddWithValue("@Email", email);

                        int rowsAffected = cmd.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            Console.WriteLine("Cadastro de cliente atualizado com sucesso.");
                        }
                        else
                        {
                            Console.WriteLine("Nenhum cliente encontrado com o nome especificado.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro ao atualizar o cliente: " + ex.Message);
            }
        }

    }
}
    