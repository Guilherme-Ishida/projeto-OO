using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoEstoque.Models
{
    public class Produto : EntidadeBase
    {
        public string Nome { get; set; }
        public decimal Preco { get; set; }
        public int Quantidade { get; set; }
        public int CategoriaId { get; set; }
        public Categoria Categoria { get; set; }

        public override string ExibirDetalhes()
        {
            return $"Nome: {Nome},Preco: {Preco}, Quantidade: {Quantidade}";
        }
    }
}

