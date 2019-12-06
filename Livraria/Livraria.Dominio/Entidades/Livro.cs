using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Livraria.Dominio.Entidades
{
    [Table("Livro")]
    public class Livro
    {
        [Key]
        public int LivroId { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(100)")]
        public string Titulo { get; set; }

        [Required]
        public int EditoraId { get; set; }

        [Required]
        public int CategoriaId { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? DataPublicacao { get; set; }

        public virtual Editora Editora { get; set; }

        public virtual Categoria Categoria { get; set; }
    }
}