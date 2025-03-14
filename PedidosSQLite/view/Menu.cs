using PedidosSQLite.model;

public class Menu
{
    public static void Main()
    {
        SQLitePCL.Batteries.Init();

        dbConexao.dbConectar();
        string Diretorio = Directory.GetCurrentDirectory();
        Console.WriteLine(Diretorio);

        dbConexao.cadastrarCliente();

        


    }
}

