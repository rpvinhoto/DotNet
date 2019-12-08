using Livraria.Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using System.Linq;

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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var cascadeFks = modelBuilder.Model.GetEntityTypes()
                .SelectMany(t => t.GetForeignKeys())
                .Where(fk => !fk.IsOwnership && fk.DeleteBehavior == DeleteBehavior.Cascade);

            foreach (var fk in cascadeFks)
                fk.DeleteBehavior = DeleteBehavior.Restrict;

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Editora> Editoras { get; set; }
        public DbSet<Livro> Livros { get; set; }
    }
}