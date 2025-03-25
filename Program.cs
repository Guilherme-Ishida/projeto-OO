using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ProjetoEstoque.Data;
using ProjetoEstoque.Services;

class Program
{
    static void Main(string[] args)
    {
        var host = Host.CreateDefaultBuilder(args)
            .ConfigureServices((context, services) =>
            {
                services.AddDbContext<EstoqueContext>(options =>
                    options.UseSqlite("Data Source=estoque.db"));

                services.AddScoped<ICategoriaService, CategoriaService>();
                services.AddScoped<IProdutoService, ProdutoService>();
            })
            .Build();

        using (var scope = host.Services.CreateScope())
        {
            var categoriaService = scope.ServiceProvider.GetRequiredService<ICategoriaService>();
            var produtoService = scope.ServiceProvider.GetRequiredService<IProdutoService>();

            while (true)
            {
                Console.WriteLine("=== Gerenciamento de Estoque ===");
                Console.WriteLine("1. Adicionar Categoria");
                Console.WriteLine("2. Adicionar Produto");
                Console.WriteLine("3. Listar Produtos");
                Console.WriteLine("4. Atualizar Produto");
                Console.WriteLine("5. Remover Produto");
                Console.WriteLine("0. Sair");
                Console.Write("Selecione uma opção: ");
                var opcao = Console.ReadLine();

                switch (opcao)
                {
                    case "1":
                        categoriaService.AdicionarCategoria();
                        break;
                    case "2":
                        produtoService.AdicionarProduto();
                        break;
                    case "3":
                        produtoService.ListarProdutos();
                        break;
                    case "4":
                        produtoService.AtualizarProduto();
                        break;
                    case "5":
                        produtoService.RemoverProduto();
                        break;
                    case "0":
                        return;
                    default:
                        Console.WriteLine("Opção inválida!");
                        break;
                }
            }
        }
    }
}
