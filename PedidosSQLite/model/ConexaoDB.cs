using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.Sqlite;
using System.IO;

//Melhoria futura: Instanciar a abertura da conexão com o banco de dados em uma classe separada para economizar linhas de código.

namespace PedidosSQLite.model
{
    public static class ConexaoDB
    {
        private static string strConexao = @"Data Source=D:\Usuários\MatheusRodriguesViei\Documents\GitHub\GerenciadorPedidosSQLite\PedidosSQLite\database\pedidosTeste.db";

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
    }
}