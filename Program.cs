using AplicativoDeComida.Data;
using AplicativoDeComida.Modelos;
using AplicativoDeComida.Services;
using AplicativoDeComida.Interfaces;
using static AplicativoDeComida.Services.GerenciamentoDeCliente;
using Microsoft.EntityFrameworkCore;
using static AplicativoDeComida.Services.GerenciamentoDeRestaurante;
using Spectre.Console;

namespace AplicativoDeComida
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var context = new AppDbContext())
            {
                context.Database.EnsureCreated();
                var gerenciamentoDeCliente = new GerenciamentoDeCliente(context);
                var gerenciamentoDeRestaurante = new GerenciamentoDeRestaurante(context);
                var gerenciamenoDeItemMenu = new GerenciamentoDeItemMenu(context);
                var gerenciamentoDePedido = new GerenciamentoDePedidos(context);
                var autenticacaoCliente = new AutenticacaoCliente(context);
                var autenticacaoRestaurate = new AutenticacaoRestaurante(context);
                var autenticacaoRestaurante = new AutenticacaoRestaurante(context);
                GerenciamentoDePedidos gerenciamentoDePedidos = new GerenciamentoDePedidos(context);



                int opcao = -1;

                while (opcao != 0)
                {
                    Console.WriteLine("Bem-vindo ao Food Delivery App!");
                    Console.WriteLine("Por favor, selecione o tipo de usuário:");
                    Console.WriteLine("1 - Cliente");
                    Console.WriteLine("2 - Restaurante");
                    Console.WriteLine("0 - Sair");

                    if (!int.TryParse(Console.ReadLine(), out opcao) || opcao < 0 || opcao > 2)
                    {
                        Console.WriteLine("Opção inválida! Por favor, selecione 1 para Cliente, 2 para Restaurante, ou 0 para Sair.");
                    }
                    else if (opcao == 1)
                    {
                        Console.WriteLine("Você selecionou Cliente!");
                        Console.WriteLine("Por favor, escolha uma opção:");
                        Console.WriteLine("1 - Fazer Login");
                        Console.WriteLine("2 - Criar Nova Conta");
                        Console.WriteLine("0 - Voltar");

                        int opcaoCliente = -1;

                        if (!int.TryParse(Console.ReadLine(), out opcaoCliente) || opcaoCliente < 0 || opcaoCliente > 2)
                        {
                            Console.WriteLine("Opção inválida! Por favor, selecione 1 para Fazer Login, 2 para Criar Nova Conta ou 0 para Voltar.");
                        }
                        else
                        {
                            switch (opcaoCliente)
                            {
                                case 0:
                                    Console.WriteLine("Voltando...");
                                    break;
                                case 1:
                                    Cliente clienteLogado = autenticacaoCliente.ValidarCliente();
                                    if (clienteLogado != null)
                                    {
                                        // Faça o que precisar com o cliente logado
                                        Console.WriteLine($"Bem-vindo, {clienteLogado.Nome}!");
                                        List<Restaurante> restaurantes = gerenciamentoDeRestaurante.ObterTodosRestaurantes();
                                        if (restaurantes != null && restaurantes.Any())
                                        {
                                            Console.Write("Digite o ID do restaurante desejado: ");
                                            if (int.TryParse(Console.ReadLine(), out int restauranteId))
                                            {
                                                Restaurante restauranteEscolhido = gerenciamentoDeRestaurante.ObterRestaurantePorId(restauranteId);

                                                if (restauranteEscolhido != null)
                                                {
                                                    Console.WriteLine($"Restaurante escolhido: {restauranteEscolhido.Nome}");
                                                    // Utilize o restaurante escolhido conforme necessário
                                                    List<ItemMenu> itensDoRestaurante = gerenciamenoDeItemMenu.ObterTodosItensMenu(restauranteId);
                                                    if (itensDoRestaurante != null && itensDoRestaurante.Any())
                                                    {
                                                        Console.WriteLine("Itens do menu disponíveis:");
                                                        foreach (var itemMenu in itensDoRestaurante)
                                                        {
                                                            string precoFormatado = itemMenu.Preco.ToString("F2");
                                                            Console.WriteLine($"ID: {itemMenu.ItemMenuId} - Nome: {itemMenu.Nome} - Descrição: {itemMenu.Descricao} - Preço: {precoFormatado}");
                                                            // Mostrar outros detalhes do item do menu, se necessário
                                                        }
                                                        // Permitir ao cliente selecionar itens para fazer um pedido
                                                        Console.WriteLine("Selecione os IDs dos itens que deseja pedir (separados por vírgula):");
                                                        string inputItens = Console.ReadLine();
                                                        List<int> itensSelecionados = inputItens.Split(',').Select(int.Parse).ToList();
                                                        // Verificação se existem itens selecionados
                                                        if (itensSelecionados.Any())
                                                        {
                                                            // Pedir o endereço de entrega após selecionar os itens
                                                            Console.WriteLine("Digite o endereço de entrega:");
                                                            string enderecoDoCliente = Console.ReadLine();

                                                            // Criar o pedido com os itens selecionados e o endereço informado
                                                            gerenciamentoDePedidos.CriarPedido(clienteLogado.ClienteId.ToString(), itensSelecionados, enderecoDoCliente);
                                                            Console.WriteLine("Pedido realizado com sucesso!");
                                                        }
                                                        else
                                                        {
                                                            Console.WriteLine("Nenhum item selecionado. Pedido não realizado.");
                                                        }

                                                    }
                                                    else
                                                    {
                                                        Console.WriteLine("Nenhum item de menu disponível para este restaurante.");
                                                    }
                                                }
                                                else
                                                {
                                                    Console.WriteLine("ID do restaurante não encontrado.");
                                                }
                                            }
                                            else
                                            {
                                                Console.WriteLine("Entrada inválida. Insira um número válido.");
                                            }
                                        }

                                    }
                                    else
                                    {
                                        Console.WriteLine("Falha no login!");
                                        // Lógica para lidar com a falha de login
                                    }
                                    break;
                                case 2:
                                    Cliente novoCliente = new Cliente();
                                    gerenciamentoDeCliente.inserirNovoCliente(novoCliente);
                                    break;
                            }
                        }
                    }
                    else if (opcao == 2)
                    {
                        Console.WriteLine("Você selecionou Restaurante!");
                        Console.WriteLine("Por favor, escolha uma opção:");
                        Console.WriteLine("1 - Fazer Login");
                        Console.WriteLine("2 - Criar Nova Conta");
                        Console.WriteLine("0 - Voltar");

                        int opcaoRestaurante = -1;

                        if (!int.TryParse(Console.ReadLine(), out opcaoRestaurante) || opcaoRestaurante < 0 || opcaoRestaurante > 2)
                        {
                            Console.WriteLine("Opção inválida! Por favor, selecione 1 para Fazer Login, 2 para Criar Nova Conta ou 0 para Voltar.");
                        }
                        else
                        {
                            switch (opcaoRestaurante)
                            {
                                case 0:
                                    Console.WriteLine("Voltando...");
                                    break;
                                case 1:
                                    Restaurante restauranteLogado = autenticacaoRestaurante.ValidarRestaurante();

                                    if (restauranteLogado != null)
                                    {
                                        // Restaurante autenticado com sucesso
                                        Console.WriteLine($"Restaurante autenticado: {restauranteLogado.Nome}");

                                        ItemMenu novoItemMenu = new ItemMenu();
                                        gerenciamenoDeItemMenu.AdicionarItemMenu();
                                        
                                        // Aqui você pode adicionar a lógica adicional para o restaurante logado
                                        // Por exemplo, listar pedidos, gerenciar cardápio, etc.
                                    }
                                    else
                                    {
                                        Console.WriteLine("Falha na autenticação do restaurante.");
                                        // Lógica para lidar com a falha de login
                                    }
                                    break;
                                case 2:
                                    Restaurante novoRestaurante = new Restaurante();
                                    gerenciamentoDeRestaurante.CriarRestaurante(novoRestaurante);
                                    break;
                            }
                        }
                    }
                }
            }
        }
    }
}
