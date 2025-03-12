using System;
using System.Collections.Generic;

namespace GerenciadorPedidos
{
    public class Menu
    {
        bool sair = false;
        
        public void menu()
        {
            try
            {
                while (!sair)
                {
                    Console.Clear();
                    Console.WriteLine("1 - Cadastrar Pedido");
                    Console.WriteLine("2 - Listar Pedidos");
                    Console.WriteLine("3 - Sair");
                    Console.WriteLine("Digite a opção desejada: ");
                    string opcao = Console.ReadLine();
                    switch (opcao)
                    {
                        case "1":
                            Pedido pedido = new Pedido();
                            Console.WriteLine("Digite o nome do cliente: ");
                            pedido.Cliente = Console.ReadLine();
                            Console.WriteLine("Digite o nome do produto: ");
                            pedido.Produto = Console.ReadLine();
                            Console.WriteLine("Digite o valor do produto: ");
                            pedido.Valor = Convert.ToDouble(Console.ReadLine());
                            pedido.Data = DateTime.Now;
                            PedidoRepository.Inserir(pedido);
                            break;
                        case "2":
                            List<Pedido> pedidos = PedidoRepository.Listar();
                            foreach (Pedido p in pedidos)
                            {
                                Console.WriteLine("Cliente: " + p.Cliente);
                                Console.WriteLine("Produto: " + p.Produto);
                                Console.WriteLine("Valor: " + p.Valor);
                                Console.WriteLine("Data: " + p.Data);
                                Console.WriteLine("====================================");
                            }
                            Console.ReadLine();
                            break;
                        case "3":
                            sair = true;
                            break;
                        default:
                            Console.WriteLine("Opção inválida");
                            Console.ReadLine();
                            break;
                    }
                }
            }
            catch (System.Exception)
            {
                
                throw;
            }

        }
    }
}
