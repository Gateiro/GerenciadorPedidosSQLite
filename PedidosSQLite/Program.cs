using System;
using Microsoft.Data.Sqlite;
using System.IO;
using PedidosSQLite.model;
using PedidosSQLite.database;
using SQLitePCL;
using System.ComponentModel.DataAnnotations.Schema;

public class Program
{
    public static void Main()
    {
        SQLitePCL.Batteries.Init();
        

        bool loop = true;
        while (loop)
        {
            Console.WriteLine("\n----- Conexão DB -----\n1) Primeira Conexão\n2) Testar conexão\n3)CriarTabelas\n4) Sair");
            string opc = Console.ReadLine();

            switch (opc)
            {
                case "1":
                    dbConexao.dbInicializar();
                    break;
                case "2":
                    if (dbConexao.dbConectar())
                    {
                        Console.WriteLine("\nConexão bem-sucedida");
                    }
                    else
                    {
                        Console.WriteLine("\nFalha na conexão");
                    }
                    break;
                case "3":
                    baseTabelas.iniciarTabelas();
                    break;
                
                case "4":
                    loop = false;
                    break;
                default:
                    Console.WriteLine("Opção inválida");
                    break;
            }
        }
    }
}
