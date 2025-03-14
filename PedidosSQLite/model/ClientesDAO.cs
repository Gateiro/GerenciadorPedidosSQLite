using System;
using Microsoft.Data.Sqlite;

namespace PedidosSQLite.model
{
    public static class ClientesDAO
    {
        private static string strConexao = @"Data Source=D:\Usuários\MatheusRodriguesViei\Documents\GitHub\GerenciadorPedidosSQLite\PedidosSQLite\database\pedidosTeste.db";

        public static void cadastrarCliente()
        {
            try
            {
                using (SqliteConnection cnx = new SqliteConnection(strConexao))
                {
                    if (cnx.State == System.Data.ConnectionState.Closed)
                    {
                        cnx.Open();
                        Console.WriteLine("\nConexão com o banco de dados estabelecida com sucesso.");

                        Console.WriteLine("\n--- CADASTRO DE CLIENTES ---\nDigite o nme: ");
                        string nome = Console.ReadLine();
                        Console.WriteLine("Digite o email: ");
                        string email = Console.ReadLine();
                        string sql = "INSERT INTO clientes (nome, email) VALUES (@nome, @email)";
                        using (SqliteCommand cmd = new SqliteCommand(sql, cnx))
                        {
                            cmd.Parameters.AddWithValue("@nome", nome);
                            cmd.Parameters.AddWithValue("@email", email);
                            cmd.ExecuteNonQuery();
                            Console.WriteLine("Cliente cadastrado com sucesso.");
                        }

                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro ao conectar com o banco de dados: " + ex.Message);
            }
        }

        public static void atualizarCliente()
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

                    Console.WriteLine("\n--- ATUALIZAÇÃO DE CLIENTES ---");
                    Console.Write("Digite o nome do cliente: ");
                    string nome = Console.ReadLine();

                    Console.Write("Digite o novo email: ");
                    string email = Console.ReadLine();

                    // Validação para que os campos não estejam vazios
                    if (string.IsNullOrWhiteSpace(nome) || string.IsNullOrWhiteSpace(email))
                    {
                        Console.WriteLine("Erro: Nome ou email não podem estar vazios.");
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

        public static void excluirCliente()
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

                    Console.WriteLine("\n--- EXCLUSÃO DE CLIENTES ---");
                    Console.Write("Digite o nome do cliente: ");
                    string nome = Console.ReadLine();

                    // Validação para que o campo não esteja vazio
                    if (string.IsNullOrWhiteSpace(nome))
                    {
                        Console.WriteLine("Erro: Nome não pode estar vazio.");
                        return;
                    }

                    string sql = "DELETE FROM clientes WHERE nome = @Nome";
                    using (SqliteCommand cmd = new SqliteCommand(sql, cnx))
                    {
                        cmd.Parameters.AddWithValue("@Nome", nome);

                        int rowsAffected = cmd.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            Console.WriteLine("Cliente excluído com sucesso.");
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
                Console.WriteLine("Erro ao excluir o cliente: " + ex.Message);
            }

        }

        public static void listarClientes(){

            try
            {
                using (SqliteConnection cnx = new SqliteConnection(strConexao))
                {
                    if (cnx.State == System.Data.ConnectionState.Closed)
                    {
                        cnx.Open();
                        Console.WriteLine("\nConexão com o banco de dados estabelecida com sucesso.");
                    }

                    string sql = "SELECT * FROM clientes";
                    using (SqliteCommand cmd = new SqliteCommand(sql, cnx))
                    {
                        using (SqliteDataReader reader = cmd.ExecuteReader())
                        {
                            Console.WriteLine("\n--- LISTA DE CLIENTES ---");
                            while (reader.Read())
                            {
                                Console.WriteLine($"Nome: {reader["nome"]}, Email: {reader["email"]}");
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro ao listar os clientes: " + ex.Message);
            }
        }
    }

}
