using Livraria.Dominio.Entidades;
using Microsoft.EntityFrameworkCore;

namespace Livraria.Dados.Contexto
{
    public class LivrariaContext : DbContext
    {
        public LivrariaContext(DbContextOptions<LivrariaContext> options) : base(options)
        {

        }

        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Editora> Editoras { get; set; }
        public DbSet<Livro> Livros { get; set; }
    }
}