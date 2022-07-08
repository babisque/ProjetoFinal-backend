using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace CastCursos.Models
{
    public class Categoria
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required]
        public string Nome { get; set; }
        [JsonIgnore]
        public virtual List<Curso> Cursos { get; set; }
    }
}
