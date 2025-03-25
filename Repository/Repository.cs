using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using ProjetoEstoque.Data;
using ProjetoEstoque.Models;

namespace ProjetoEstoque.Repositories
{
    public class Repository<T> : IRepository<T> where T : EntidadeBase
    {
        protected readonly EstoqueContext _context;

        public Repository(EstoqueContext context)
        {
            _context = context;
        }

        public T ObterPorId(int id)
        {
            return _context.Set<T>().Find(id);
        }

        public IEnumerable<T> ObterTodos()
        {
            return _context.Set<T>().ToList();
        }

        public void Adicionar(T entidade)
        {
            _context.Set<T>().Add(entidade);
            _context.SaveChanges();
        }

        public void Atualizar(T entidade)
        {
            _context.Set<T>().Update(entidade);
            _context.SaveChanges();
        }

        public void Remover(int id)
        {
            var entidade = ObterPorId(id);
            if (entidade != null)
            {
                _context.Set<T>().Remove(entidade);
                _context.SaveChanges();
            }
        }
    }
}
