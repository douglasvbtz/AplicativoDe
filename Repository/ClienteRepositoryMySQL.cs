using AplicativoDeComida.Interfaces;
using AplicativoDeComida.Data;
using AplicativoDeComida.Modelos;

namespace AplicativoDeComida.Controller
{
    public class ClienteRepositoryMySQL : IRepositorio<Cliente>
    {
        private readonly AppDbContext _context;

        public ClienteRepositoryMySQL(AppDbContext context)
        {
            _context = context;
        }

        public void Inserir(Cliente entidade)
        {
            _context.Clientes.Add(entidade);
            _context.SaveChanges();
        }

        public void Atualizar(int id, Cliente newEntity)
        {
            var cliente = _context.Clientes.Find(id);
            if (cliente != null)
            {
                cliente.Nome = newEntity.Nome;
                // Atualize outros campos conforme necessário
                _context.SaveChanges();
            }
        }

        public void Excluir(int? id)
        {
            var cliente = _context.Clientes.Find(id);
            if (cliente != null)
            {
                _context.Clientes.Remove(cliente);
                _context.SaveChanges();
            }
        }

        public Cliente ObterPorId(int? id)
        {
            return _context.Clientes.Find(id);
        }

        public List<Cliente> ObterTodos()
        {
            return _context.Clientes.ToList();
        }

        public Cliente ExisteNaBaseDeDados(string tabela, string coluna, string dado)
        {
            // Lógica para verificar se o cliente existe na base de dados usando a tabela, coluna e dado fornecidos
            // Retorne um Cliente se existir, ou null se não existir
            return _context.Clientes.FirstOrDefault(c => c.Email == dado);
        }
        // Outros métodos conforme necessário
    }

}
