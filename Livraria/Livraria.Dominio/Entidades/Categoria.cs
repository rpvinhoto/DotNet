using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Livraria.Dominio.Entidades
{
    [Table("Categoria")]
    public class Categoria
    {
        [Key]
        public int CategoriaId { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(100)")]
        public string Nome { get; set; }

        public virtual IEnumerable<Livro> Livros { get; set; }
    }
}