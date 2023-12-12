using AplicativoDeComida.Interfaces;
using AplicativoDeComida.Data;
using AplicativoDeComida.Modelos;
using System.Collections.Generic;
using System.Linq;

namespace AplicativoDeComida.Controller
{
    public class ItemMenuRepositoryMySQL : IRepositorio<ItemMenu>
    {
        private readonly AppDbContext _context;

        public ItemMenuRepositoryMySQL(AppDbContext context)
        {
            _context = context;
        }

        public void Inserir(ItemMenu entidade)
        {
            _context.ItensMenu.Add(entidade);
            _context.SaveChanges();
        }

        public void Atualizar(int id, ItemMenu newEntity)
        {
            var itemMenu = _context.ItensMenu.Find(id);
            if (itemMenu != null)
            {
                itemMenu.ItemMenuId = newEntity.ItemMenuId;
                // Atualize outros campos conforme necessário
                _context.SaveChanges();
            }
        }

        public void Excluir(int? id)
        {
            var itemMenu = _context.ItensMenu.Find(id);
            if (itemMenu != null)
            {
                _context.ItensMenu.Remove(itemMenu);
                _context.SaveChanges();
            }
        }
        public List<ItemMenu> ObterTodosItensMenu(int restauranteId)
        {
            // Lógica para obter todos os itens de menu de um restaurante específico
            return _context.ItensMenu.Where(item => item.RestauranteId == restauranteId).ToList();
        }

        public ItemMenu ObterPorId(int? id)
        {
            return _context.ItensMenu.Find(id);
        }

        public List<ItemMenu> ObterTodos()
        {
            return _context.ItensMenu.ToList();
        }

        // Método ExisteNaBaseDeDados pode não ser necessário para a entidade ItemMenu

        // Outros métodos conforme necessário
        public ItemMenu ExisteNaBaseDeDados(string tabela, string coluna, string dado)
        {
            if (coluna == "ItemMenuId") // Verifique a coluna correta que está sendo comparada
            {
                int itemMenuId;
                if (int.TryParse(dado, out itemMenuId))
                {
                    return _context.ItensMenu.FirstOrDefault(i => i.ItemMenuId == itemMenuId);
                }
            }

            return null; // Se a coluna ou dado não corresponderem ao identificador correto, retorne null
        }

    }
}
