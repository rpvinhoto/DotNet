using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Livraria.Dominio.Entidades
{
    [Table("Livro")]
    public class Livro
    {
        [Key]
        public long LivroId { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(100)")]
        public string Titulo { get; set; }

        [Required]
        public long EditoraId { get; set; }

        [Required]
        public long CategoriaId { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? DataPublicacao { get; set; }

        [JsonIgnore]
        public virtual Editora Editora { get; set; }

        [JsonIgnore]
        public virtual Categoria Categoria { get; set; }
    }
}