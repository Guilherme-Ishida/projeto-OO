using System;
using System.Collections.Generic;
using ProjetoEstoque.Models;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ProjetoEstoque.Repositories
{
    public interface IRepository<T> where T : EntidadeBase
    {
        T ObterPorId(int id);
        IEnumerable<T> ObterTodos();
        void Adicionar(T entidade);
        void Atualizar(T entidade);
        void Remover(int id);
    }
}

