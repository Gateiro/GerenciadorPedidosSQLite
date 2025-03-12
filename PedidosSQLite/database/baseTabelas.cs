using System;
using Microsoft.Data.Sqlite;
using System.IO;
using PedidosSQLite.model;

namespace PedidosSQLite.database
{
    public static class baseTabelas
    {
        
        public static void iniciarTabelas()
        {
            dbConexao.dbConectar();
            using (var db = new SqliteConnection($"Filename={dbConexao.dbConectar()}"))
            {
                db.Open();
                tabClientes(db);
                tabProdutos(db);
                tabItens(db);
            }
        }
        
        public static void tabClientes(SqliteConnection db)
        {
            //Estrutura da tabela
            string criarTabela = @"CREATE TABLE IF NOT EXISTS Clientes(
            Id INTEGER PRIMARY KEY AUTOINCREMENT,
            Nome NVARCHAR(100) NOT NULL,
            Email NVARCHAR(100) NOT NULL,         
            )";

            using (var createTable = new SqliteCommand(criarTabela, db))
            {
                createTable.ExecuteNonQuery();
                Console.WriteLine("Tabela Clientes criada com sucesso");
            }

        }

        public static void tabProdutos(SqliteConnection db)
        {
            //Estrutura da tabela
            string criarTabela = @"CREATE TABLE IF NOT EXISTS Produtos(
            Id INTEGER PRIMARY KEY AUTOINCREMENT,
            Nome NVARCHAR(100) NOT NULL,
            Preco REAL NOT NULL,
            Estoque INTEGER NOT NULL         
            )";

            using (var createTable = new SqliteCommand(criarTabela, db))
            {
                createTable.ExecuteNonQuery();
                Console.WriteLine("Tabela Produtos criada com sucesso");
            }

        }

        public static void tabItens(SqliteConnection db)
        {
            //Estrutura da tabela
            string criarTabela = @"CREATE TABLE IF NOT EXISTS ItensPedidos(
            Id INTEGER PRIMARY KEY AUTOINCREMENT,
            PedidosId INTEGER FOREIGN KEY REFERENCES Pedidos(Id),
            ProdutosId INTEGER FOREIGN KEY REFERENCES Produtos(Id),
            Quantidade INTEGER NOT NULL         
            PrecoTotal REAL NOT NULL        
            )";

            using (var createTable = new SqliteCommand(criarTabela, db))
            {
                createTable.ExecuteNonQuery();
                Console.WriteLine("Tabela Itens Pedidos criada com sucesso");
            }

        }

        //!!!!! Anexar o método abaixo ao menu de testes com  a base de dados!!!!!
        public static void ListarTabelas(SqliteConnection db)
        {
            string listarTabelas = "SELECT name FROM sqlite_master WHERE type='table';";

            using (var command = new SqliteCommand(listarTabelas, db))
            {
                using (var reader = command.ExecuteReader())
                {
                    Console.WriteLine("Tabelas existentes no banco de dados:");
                    while (reader.Read())
                    {
                        Console.WriteLine(reader.GetString(0));
                    }
                }
            }
        }
    }

    
}