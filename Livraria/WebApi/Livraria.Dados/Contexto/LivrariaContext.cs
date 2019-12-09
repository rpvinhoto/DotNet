using Livraria.Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace Livraria.Dados.Contexto
{
    public class LivrariaContext : DbContext
    {
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Editora> Editoras { get; set; }
        public DbSet<Livro> Livros { get; set; }

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

            modelBuilder.Entity<Categoria>().HasData(new Categoria { CategoriaId = 1, Nome = "Ficção" });
            modelBuilder.Entity<Categoria>().HasData(new Categoria { CategoriaId = 2, Nome = "Fábula" });
            modelBuilder.Entity<Categoria>().HasData(new Categoria { CategoriaId = 3, Nome = "Biografia" });

            modelBuilder.Entity<Editora>().HasData(new Editora { EditoraId = 1, Nome = "Aleph" });
            modelBuilder.Entity<Editora>().HasData(new Editora { EditoraId = 2, Nome = "Reynal & Hitchcock" });

            modelBuilder.Entity<Livro>().HasData(new Livro { LivroId = 1, CategoriaId = 1, EditoraId = 1, Titulo = "Neuromancer", DataPublicacao = new DateTime(1984, 7, 1) });
            modelBuilder.Entity<Livro>().HasData(new Livro { LivroId = 2, CategoriaId = 2, EditoraId = 2, Titulo = "The Little Prince", DataPublicacao = new DateTime(1943, 4, 6) });

            base.OnModelCreating(modelBuilder);
        }
    }
}