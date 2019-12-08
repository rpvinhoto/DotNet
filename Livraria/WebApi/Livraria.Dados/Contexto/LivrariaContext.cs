using Livraria.Dominio.Entidades;
using Microsoft.EntityFrameworkCore;

namespace Livraria.Dados.Contexto
{
    public class LivrariaContext : DbContext
    {
        public LivrariaContext()
        {
        }

        public LivrariaContext(DbContextOptions<LivrariaContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=LivrariaDB;Trusted_Connection=True;MultipleActiveResultSets=True;");
            }

            base.OnConfiguring(optionsBuilder);
        }

        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Editora> Editoras { get; set; }
        public DbSet<Livro> Livros { get; set; }
    }
}