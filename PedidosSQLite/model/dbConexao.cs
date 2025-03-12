using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.Sqlite;
using System.IO; // Adicionado como alternativa para gerenciar o caminho até o arquivo do DB

namespace PedidosSQLite.model
{
    public static class dbConexao
    {
        public static void dbInicializar() //Valida se o arquivo do DB existe, caso não exista, cria o arquivo e a tabela
        {
            string pastaLocal = AppDomain.CurrentDomain.BaseDirectory; // Obtem a pasta base do projeto
            string dbCaminho = Path.Combine(pastaLocal, "pedidos.db"); // Cria o caminho até o arquivo do DB

            if (!File.Exists(dbCaminho))
            {
                using (FileStream fs = File.Create(dbCaminho))
                {
                    Console.WriteLine("Banco de dados criado com sucesso");   // O arquivo é criado aqui
                }
            }
            else
            {
                Console.WriteLine("Banco de dados já existe");
            }

            using (var db = new SqliteConnection($"Filename={dbCaminho}"))
            {
                db.Open();

                string criarTabela = "CREATE TABLE IF NOT " +
                    "EXISTS MyTable (Primary_Key INTEGER PRIMARY KEY, " +
                    "Text_Entry NVARCHAR(2048) NULL)";

                var createTable = new SqliteCommand(criarTabela, db);

                createTable.ExecuteReader();
            }
        }

        public static bool dbConectar()
        {
            string pastaLocal = AppDomain.CurrentDomain.BaseDirectory; // Obtem a pasta base do projeto
            string dbCaminho = Path.Combine(pastaLocal, "pedidos.db"); // Cria o caminho até o arquivo do DB

            try
            {
                using (var db = new SqliteConnection($"Filename={dbCaminho}"))
                {
                    db.Open();
                    return true; // Conexão bem-sucedida
                }
            }
            catch (Exception)
            {
                return false; // Falha na conexão
            }
        }
    }
}
