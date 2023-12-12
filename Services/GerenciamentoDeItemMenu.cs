using AplicativoDeComida.Controller;
using AplicativoDeComida.Data;
using AplicativoDeComida.Modelos;

namespace AplicativoDeComida.Services
{
    public class GerenciamentoDeItemMenu
    {
        private readonly AppDbContext _context;
        private readonly ItemMenuRepositoryMySQL _itemMenuRepository;

        public GerenciamentoDeItemMenu(AppDbContext context)
        {
            _context = context;
            _itemMenuRepository = new ItemMenuRepositoryMySQL(_context);
        }

        public void AdicionarItemMenu()
        {

            ItemMenu novoItem = new ItemMenu();

            Console.WriteLine("Digite o nome do novo item:");
            novoItem.Nome = Console.ReadLine();

            Console.WriteLine("Digite a descrição do novo item:");
            novoItem.Descricao = Console.ReadLine();

            Console.WriteLine("Digite o preço do novo item:");
            if (decimal.TryParse(Console.ReadLine(), out decimal preco))
            {
                novoItem.Preco = preco;
            }
            else
            {
                Console.WriteLine("Preço inválido!");
                return;
            }

            try
            {
                _itemMenuRepository.Inserir(novoItem);
                Console.WriteLine("Novo item adicionado com sucesso!");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro ao adicionar item: " + ex.Message);
                throw;
            }
        }

        public void AtualizarItemMenu()
        {
            Console.WriteLine("Digite o ID do item que deseja atualizar:");
            if (int.TryParse(Console.ReadLine(), out int id))
            {
                ItemMenu itemExistente = _itemMenuRepository.ObterPorId(id);

                if (itemExistente != null)
                {
                    Console.WriteLine("Digite o novo nome do item:");
                    itemExistente.Nome = Console.ReadLine();

                    Console.WriteLine("Digite a nova descrição do item:");
                    itemExistente.Descricao = Console.ReadLine();

                    Console.WriteLine("Digite o novo preço do item:");
                    if (decimal.TryParse(Console.ReadLine(), out decimal novoPreco))
                    {
                        itemExistente.Preco = novoPreco;
                    }
                    else
                    {
                        Console.WriteLine("Preço inválido!");
                        return;
                    }

                    _itemMenuRepository.Atualizar(id, itemExistente);
                    Console.WriteLine("Item atualizado com sucesso!");
                }
                else
                {
                    Console.WriteLine("Item não encontrado!");
                }
            }
            else
            {
                Console.WriteLine("ID inválido!");
            }
        }

        public void RemoverItemMenu()
        {
            Console.WriteLine("Digite o ID do item que deseja remover:");
            if (int.TryParse(Console.ReadLine(), out int id))
            {
                _itemMenuRepository.Excluir(id);
                Console.WriteLine("Item removido com sucesso!");
            }
            else
            {
                Console.WriteLine("ID inválido!");
            }
        }

        public ItemMenu ObterItemMenuPorId(int id)
        {
            return _itemMenuRepository.ObterPorId(id);
        }

        public List<ItemMenu> ObterTodosItensMenu(int restauranteId)
        {
            return _context.ItensMenu.Where(item => item.RestauranteId == restauranteId).ToList();
        }

        // Outros métodos do GerenciamentoDeItemMenu conforme necessário
    }
}
