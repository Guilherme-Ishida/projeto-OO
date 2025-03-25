using System;
using System.Collections.Generic;
using ProjetoEstoque.Models;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace ProjetoEstoque.Repositories
{
    public interface IProdutoRepositorio : IRepository<Produto>
    {
        IEnumerable<Produto> ObterProdutosComDetalhes();
    }
}

