using System;
using Microsoft.Data.Sqlite;
using System.IO;
using PedidosSQLite.model;
using SQLitePCL;



public class Program

{
    public static void Main()
    {
        SQLitePCL.Batteries.Init();

        
        Console.WriteLine("----- Conexão DB -----\n1) Primeira Conexão\n2) Testar conexão\n3) Sair");
        string opc = Console.ReadLine();
        bool loop = true;
        while (loop)
        {
            switch (opc)
            {
                case "1":
                    dbConexao.dbInicializar();
                    break;
                case "2":
                    if (dbConexao.dbConectar())
                    {
                        Console.WriteLine("Conexão bem-sucedida");
                    }
                    else
                    {
                        Console.WriteLine("Falha na conexão");
                    }
                    break;
                case "3":
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Opção inválida");
                    break;
            }
        }
        

    }
}
