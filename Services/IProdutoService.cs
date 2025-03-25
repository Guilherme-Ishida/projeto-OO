using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoEstoque.Services
{
    public interface IProdutoService
    {
        void AdicionarProduto();
        void ListarProdutos();
        void AtualizarProduto();
        void RemoverProduto();
    }
}

