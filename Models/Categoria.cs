using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoEstoque.Models
{
    public class Categoria : EntidadeBase
    {
        public string Nome { get; set; }
        public List<Produto> Produtos { get; set; }

        public override string ExibirDetalhes()
        {
            return $"Nome: {Nome}";
        }
    }
}
