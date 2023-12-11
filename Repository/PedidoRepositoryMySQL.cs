using AplicativoDeComida.Interfaces;
using AplicativoDeComida.Data;
using AplicativoDeComida.Modelos;
using Microsoft.EntityFrameworkCore;

namespace AplicativoDeComida.Controller
{
    public class PedidoRepositoryMySQL : IRepositorio<Pedido>
    {
        private readonly AppDbContext _context;

        public PedidoRepositoryMySQL(AppDbContext context)
        {
            _context = context;
        }

        public void Inserir(Pedido entidade)
        {
            _context.Pedidos.Add(entidade);
            _context.SaveChanges();
        }

        public void Atualizar(int id, Pedido newEntity)
        {
            var pedido = _context.Pedidos.Find(id);
            if (pedido != null)
            {
                pedido.Status = newEntity.Status;
                // Atualize outros campos conforme necessário
                _context.SaveChanges();
            }
        }

        public void Excluir(int? id)
        {
            var pedido = _context.Pedidos.Find(id);
            if (pedido != null)
            {
                _context.Pedidos.Remove(pedido);
                _context.SaveChanges();
            }
        }

        public Pedido ObterPorId(int? id)
        {
            return _context.Pedidos.Find(id);
        }
        // Adicione um método para associar itens de menu a um pedido
        public void AssociarItensMenuPedido(int pedidoId, List<ItemMenu> itensMenu)
        {
            var pedido = _context.Pedidos.Include(p => p.Menu).FirstOrDefault(p => p.PedidoId == pedidoId);

            if (pedido != null)
            {
                // Adicione os itens de menu ao pedido
                foreach (var item in itensMenu)
                {
                    pedido.Menu.Add(item);
                }

                _context.SaveChanges();
            }
        }

        // Adicione um método para obter todos os itens de menu de um pedido específico
        public List<ItemMenu> ObterItensMenuPedido(int pedidoId)
        {
            var pedido = _context.Pedidos.Include(p => p.Menu).FirstOrDefault(p => p.PedidoId == pedidoId);

            return pedido?.Menu.ToList();
        }

        public List<Pedido> ObterTodos()
        {
            return _context.Pedidos.ToList();
        }

        // O método ExisteNaBaseDeDados pode não ser necessário para a entidade Pedido

        // Outros métodos conforme necessário
        public Pedido ExisteNaBaseDeDados(string tabela, string coluna, string dado)
        {
            if (coluna == "PedidoId") // Verifique a coluna correta que está sendo comparada
            {
                int pedidoId;
                if (int.TryParse(dado, out pedidoId))
                {
                    return _context.Pedidos.FirstOrDefault(p => p.PedidoId == pedidoId);
                }
            }

            return null; // Se a coluna ou dado não corresponderem ao identificador correto, retorne null
        }
    }
}
