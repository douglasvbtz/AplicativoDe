using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AplicativoDeComida.Interfaces
{
    public interface IRepositorio<T>
    {
        public void Inserir(T entity);
        public void Atualizar(int id, T newEntity);
        public void Excluir(int? id);
        public T ObterPorId(int? id);
        public List<T> ObterTodos();
        public T ExisteNaBaseDeDados(string tabela, string coluna, string dado);
    }    
}