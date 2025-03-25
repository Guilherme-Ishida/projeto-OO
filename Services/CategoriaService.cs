using ProjetoEstoque.Data;
using ProjetoEstoque.Models;

namespace ProjetoEstoque.Services
{
    public class CategoriaService : ICategoriaService
    {
        private readonly EstoqueContext _db;

        public CategoriaService(EstoqueContext db)
        {
            _db = db;
        }

        public void AdicionarCategoria()
        {
            try
            {
                Console.Write("Nome da categoria: ");
                var nome = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(nome))
                {
                    Console.WriteLine("Nome da categoria não pode ser vazio.");
                    return;
                }

                var categoria = new Categoria { Nome = nome };

                _db.Categorias.Add(categoria);
                _db.SaveChanges();
                Console.WriteLine("Categoria adicionada com sucesso!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ocorreu um erro ao adicionar a categoria: {ex.Message}");
                if (ex.InnerException != null)
                {
                    Console.WriteLine($"Detalhes do erro: {ex.InnerException.Message}");
                }
            }
        }
    }
}
