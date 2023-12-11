using AplicativoDeComida.Interfaces;
using AplicativoDeComida.Data;
using AplicativoDeComida.Modelos;
using System.Collections.Generic;
using System.Linq;

namespace AplicativoDeComida.Controller
{
    public class RestauranteRepositoryMySQL : IRepositorio<Restaurante>
    {
        private readonly AppDbContext _context;

        public RestauranteRepositoryMySQL(AppDbContext context)
        {
            _context = context;
        }

        public void Inserir(Restaurante entidade)
        {
            _context.Restaurantes.Add(entidade);
            _context.SaveChanges();
        }

        public void Atualizar(int id, Restaurante newEntity)
        {
            var restaurante = _context.Restaurantes.Find(id);
            if (restaurante != null)
            {
                restaurante.Nome = newEntity.Nome;
                restaurante.email = newEntity.email;
                restaurante.senha = newEntity.senha;
                // Atualize outros campos conforme necessário
                _context.SaveChanges();
            }
        }

        public void Excluir(int? id)
        {
            var restaurante = _context.Restaurantes.Find(id);
            if (restaurante != null)
            {
                _context.Restaurantes.Remove(restaurante);
                _context.SaveChanges();
            }
        }

        public Restaurante ObterPorId(int? id)
        {
            return _context.Restaurantes.Find(id);
        }

        public List<Restaurante> ObterTodos()
        {
            return _context.Restaurantes.ToList();
        }

        public Restaurante ExisteNaBaseDeDados(string tabela, string coluna, string dado)
        {
            return _context.Restaurantes.FirstOrDefault(r => r.email == dado);
        }
        // Outros métodos conforme necessário
    }
}
