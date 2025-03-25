using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using ProjetoEstoque.Data;
using ProjetoEstoque.Models;

namespace ProjetoEstoque.Repositories
{
    public class ProdutoRepositorio : Repository<Produto>, IProdutoRepositorio
    {
        public ProdutoRepositorio(EstoqueContext context) : base(context)
        {
        }

        public IEnumerable<Produto> ObterProdutosComDetalhes()
        {
            return _context.Produtos.Include(p => p.Categoria).ToList();
        }
    }
}
