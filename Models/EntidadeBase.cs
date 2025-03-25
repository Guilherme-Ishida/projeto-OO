using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoEstoque.Models
{
    public abstract class EntidadeBase
    {
        public int Id { get; set; }
        public abstract string ExibirDetalhes();

    }

}
