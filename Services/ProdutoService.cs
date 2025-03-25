using Microsoft.EntityFrameworkCore;
using ProjetoEstoque.Data;
using ProjetoEstoque.Models;

namespace ProjetoEstoque.Services
{
    public class ProdutoService : IProdutoService
    {
        private readonly EstoqueContext _db;

        public ProdutoService(EstoqueContext db)
        {
            _db = db;
        }

        public void AdicionarProduto()
        {
            try
            {
                Console.Write("Nome do produto: ");
                var nome = Console.ReadLine();
                Console.Write("Preço do produto: ");
                if (!decimal.TryParse(Console.ReadLine(), out var preco))
                {
                    Console.WriteLine("Preço inválido.");
                    return;
                }
                Console.Write("Quantidade do produto: ");
                if (!int.TryParse(Console.ReadLine(), out var quantidade))
                {
                    Console.WriteLine("Quantidade inválida.");
                    return;
                }

                var categorias = _db.Categorias.ToList();
                if (!categorias.Any())
                {
                    Console.WriteLine("Nenhuma categoria encontrada. Por favor, adicione uma categoria primeiro.");
                    return;
                }

                Console.WriteLine("Selecione uma categoria:");
                for (int i = 0; i < categorias.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {categorias[i].Nome}");
                }
                if (!int.TryParse(Console.ReadLine(), out var categoriaId) || categoriaId < 1 || categoriaId > categorias.Count)
                {
                    Console.WriteLine("Categoria inválida.");
                    return;
                }

  
       

                var produto = new Produto
                {
                    Nome = nome,
                    Preco = preco,
                    Quantidade = quantidade,
                    CategoriaId = categorias[categoriaId - 1].Id,

                };

                _db.Produtos.Add(produto);
                _db.SaveChanges();
                Console.WriteLine("Produto adicionado com sucesso!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ocorreu um erro ao adicionar o produto: {ex.Message}");
            }
        }

        public void ListarProdutos()
        {
            try
            {
                var produtos = _db.Produtos.Include(p => p.Categoria);
                if (!produtos.Any())
                {
                    Console.WriteLine("Nenhum produto encontrado.");
                    return;
                }

                foreach (var p in produtos)
                {
                    Console.WriteLine($"Produto: {p.Nome}, Categoria: {p.Categoria.Nome}, Preço: {p.Preco}, Quantidade: {p.Quantidade}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ocorreu um erro ao listar os produtos: {ex.Message}");
            }
        }

        public void AtualizarProduto()
        {
            try
            {
                ListarProdutos();
                Console.Write("Digite o ID do produto para atualizar: ");
                if (!int.TryParse(Console.ReadLine(), out var produtoId))
                {
                    Console.WriteLine("ID inválido.");
                    return;
                }

                var produto = _db.Produtos.Find(produtoId);
                if (produto == null)
                {
                    Console.WriteLine("Produto não encontrado!");
                    return;
                }

                Console.Write("Novo nome do produto (deixe vazio para manter): ");
                var nome = Console.ReadLine();
                if (!string.IsNullOrEmpty(nome)) produto.Nome = nome;

                Console.Write("Novo preço do produto (deixe vazio para manter): ");
                var preco = Console.ReadLine();
                if (!string.IsNullOrEmpty(preco) && decimal.TryParse(preco, out var novoPreco))
                {
                    produto.Preco = novoPreco;
                }

                Console.Write("Nova quantidade do produto (deixe vazio para manter): ");
                var quantidade = Console.ReadLine();
                if (!string.IsNullOrEmpty(quantidade) && int.TryParse(quantidade, out var novaQuantidade))
                {
                    produto.Quantidade = novaQuantidade;
                }

                _db.SaveChanges();
                Console.WriteLine("Produto atualizado com sucesso!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ocorreu um erro ao atualizar o produto: {ex.Message}");
            }
        }

        public void RemoverProduto()
        {
            try
            {
                ListarProdutos();
                Console.Write("Digite o ID do produto para remover: ");
                if (!int.TryParse(Console.ReadLine(), out var produtoId))
                {
                    Console.WriteLine("ID inválido.");
                    return;
                }

                var produto = _db.Produtos.Find(produtoId);
                if (produto == null)
                {
                    Console.WriteLine("Produto não encontrado!");
                    return;
                }

                _db.Produtos.Remove(produto);
                _db.SaveChanges();
                Console.WriteLine("Produto removido com sucesso!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ocorreu um erro ao remover o produto: {ex.Message}");
            }
        }
    }
}
