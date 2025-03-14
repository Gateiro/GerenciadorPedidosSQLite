﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.Sqlite;
using System.IO;


namespace PedidosSQLite.model
{
    public static class dbConexao
    {
        private static string strConexao = @"Data Source=C:\Users\mathe\OneDrive\Documentos\Github\GerenciadorPedidosSQLite\PedidosSQLite\database\pedidosTeste.db";

        public static void dbConectar()
        {
            try
            {
                using (SqliteConnection cnx = new SqliteConnection(strConexao))
                {
                    if (cnx.State == System.Data.ConnectionState.Closed)
                    {
                        cnx.Open();
                        Console.WriteLine("Conexão com o banco de dados estabelecida com sucesso.");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro ao conectar com o banco de dados: " + ex.Message);
            }
        }

        public static void cadastrarCliente()
        {
            try
            {
                using (SqliteConnection cnx = new SqliteConnection(strConexao))
                {
                    if (cnx.State == System.Data.ConnectionState.Closed)
                    {
                        cnx.Open();
                        Console.WriteLine("Conexão com o banco de dados estabelecida com sucesso.");

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
    }
}
