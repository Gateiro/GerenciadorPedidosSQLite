using PedidosSQLite.model;

public class Menu
{
    public static void Main()
    {
        SQLitePCL.Batteries.Init();

        // Conectar ao banco de dados
        ConexaoDB.dbConectar();

        // Exibir o diretório atual
        string Diretorio = Directory.GetCurrentDirectory();
        Console.WriteLine("Diretório atual: " + Diretorio);
        ClientesDAO.listarClientes();
        // Cadastrar um cliente
        ClientesDAO.cadastrarCliente();
    }
}