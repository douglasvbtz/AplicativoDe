using AplicativoDeComida.Modelos;
using AplicativoDeComida.Data;
using AplicativoDeComida.Services;
using Spectre.Console;

namespace AplicativoDeComida
{
    class Program
    {
        static Cliente clienteAtual = null;
        
        static void Main(string[] args)
        {
            try
            {
                Console.BackgroundColor = Color.Black;
                Console.Clear();
                
                using (var context = new AppDbContext())
                {
                    context.Database.EnsureCreated();
    
                    var gerDeCliente = new GerenciamentoDeCliente(context);
                    var gerDeRestaurante = new GerenciamentoDeRestaurante(context);
                    var gerDeItemMenu = new GerenciamentoDeItemMenu(context);
                    var gerDePedidos = new GerenciamentoDePedidos(context);
    
                    while (true)
                    {
                        var opcao = AnsiConsole.Prompt(
                            new SelectionPrompt<(int Index, string Name)>()
                               .AddChoices(new List<(int Index, string Name)>
                               {
                                   (1, "Sou um cliente"),
                                   (2, "Sou um restaurante"),
                                   (0, "Sair")
                               })
                               .UseConverter(a => a.Name)
                               .HighlightStyle(new Style().Background(Color.DarkBlue).Foreground(Color.White))
                               .Title("=== Menu Principal ===")
                        );
                        switch(opcao.Index)
                        {
                            case 0: 
                                Console.Clear();
                                return;
                            case 1:
                                MenuCliente(gerDeCliente, gerDeRestaurante, gerDePedidos);
                                break;
                            case 2:
                                clienteAtual = gerDeCliente.inserirNovoCliente();
                                if (clienteAtual != null)
                                {
                                    Console.Clear();
                                    MenuCliente(gerDeCliente, gerDeRestaurante, gerDePedidos);
                                }
                                break;
                        }
                    }
                }
            }
            catch (Microsoft.EntityFrameworkCore.DbUpdateException e)
            {
                Console.WriteLine("Não é possivel alterar esse dado.");
            }
            catch (MySqlConnector.MySqlException e)
            {
                Console.WriteLine("Erro de Conexao.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro inesperado: {ex.Message}");
            }
        } 
        static void MenuCliente(GerenciamentoDeCliente gerDeCliente, GerenciamentoDeRestaurante gerDeRestaurante, GerenciamentoDePedidos gerDePedidos)
        {
            while (true)
            {
                if (clienteAtual == null)
                {
                    clienteAtual = gerDeCliente.ValidarCliente();
                    Console.Clear();
                }
                else
                {
                    // Console.Clear();
                    var opcao = AnsiConsole.Prompt(
                        new SelectionPrompt<(int Index, string Name)>()
                            .AddChoices(new List<(int Index, string Name)>
                            {
                                (1, "Realizar pedido"),
                                (2, "Ver pedidos"),
                                (3, "Ver informações do usuário"),
                                (0, "Voltar")
                            })
                            .UseConverter(a => a.Name)
                            .HighlightStyle(new Style().Background(Color.DarkBlue).Foreground(Color.White))
                            .Title("=== Menu do Usuário ===")
                    );
                    switch (opcao.Index)
                    {
                        case 0:
                            Console.Clear();
                            return;
                        case 1:
                            Console.Clear();
                            // gerDePedidos.CriarPedido();
                            break;
                        case 2:
                            Console.Clear();
                            // MenuTarefas(gerDeRestaurante, gerDeItemMenu, context);
                            break;
                        case 3:
                            Console.Clear();
                            Console.WriteLine($"ID: {clienteAtual.ClienteId}, Nome: {clienteAtual.Nome}, Email: {clienteAtual.Email}");
                            break;
                    }
                }
            }
        }

        static void MenuTarefas(GerenciamentoDeRestaurante gerDeRestaurante, GerenciamentoDeItemMenu gerDeItemMenu)
        {
            while (true)
            {
               var opcao = AnsiConsole.Prompt(
                    new SelectionPrompt<(int Index, string Name)>()
                        .AddChoices( new List<(int Index, string Name)>
                        {
                            (1, "Cadastrar item no menu"),
                            (2, "Alterar item no menu"),
                            (3, "Excluir item do menu"),
                            (4, "Ver itens"),
                            (0, "Voltar")
                        })
                        .UseConverter(a => a.Name)
                        .HighlightStyle(Color.Blue)
                        .Title("=== Menu de Tarefas ===")
                );
                switch(opcao.Index)
                {
                    case 0:
                        Console.Clear();
                        return;
                    case 1:
                        Console.Clear();
                        // gerDeRestaurante.Add(context, clienteAtual);
                        break;
                    case 2:
                        Console.Clear();
                        // gerDeRestaurante.UpdateTarefa(context,gerDeRestaurante, gerDeItemMenu, clienteAtual);
                        break;
                    case 3:
                        Console.Clear();
                        // gerDeRestaurante.Delete(gerDeRestaurante, gerDeItemMenu, clienteAtual);
                        break;
                    case 4:
                        Console.Clear();
                        // gerDeRestaurante.GetAllTarefas(gerDeRestaurante, gerDeItemMenu, clienteAtual);
                        break;
                }
            }
        }
        
        //
        // static void MenuListas(GerenciamentoDeItemMenu gerDeItemMenu, DataContext? context)
        // {
        //     while (true)
        //     {
        //         var opcao = AnsiConsole.Prompt(
        //             new SelectionPrompt<(int Index, string Name)>()
        //                 .AddChoices( new List<(int Index, string Name)>
        //                 {
        //                     (0, "Voltar"),
        //                     (1, "Adicionar Lista"),
        //                     (2, "Alterar lista"),
        //                     (3, "Excluir lista"),
        //                     (4, "Buscar listas")
        //                 })
        //                 .UseConverter(a => a.Name)
        //                 .HighlightStyle(Color.Blue)
        //                 .Title("=== Menu de Listas ===")
        //         );
        //         switch(opcao.Index)
        //         {
        //             case 0:
        //                 Console.Clear();
        //                 return;
        //             case 1:
        //                 Console.Clear();
        //                 gerDeItemMenu.Add(context, clienteAtual);
        //                 break;
        //             case 2:
        //                 Console.Clear();
        //                 gerDeItemMenu.UpdateLista(context, gerDeItemMenu, clienteAtual);
        //                 break;
        //             case 3:
        //                 Console.Clear();
        //                 gerDeItemMenu.Delete(gerDeItemMenu, clienteAtual);
        //                 break;
        //             case 4:
        //                 Console.Clear();
        //                 gerDeItemMenu.GetAllListas(gerDeItemMenu, clienteAtual);
        //                 break;
        //         }
        //     }
        // }
    }
}
