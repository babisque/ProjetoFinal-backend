using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace CastCursos.Models
{
    public class Curso : IValidatableObject
    {
        [Key]
        [Required]
        public int Id { get; internal set; }
        [Required]
        public string Nome { get; set; }
        [Required]
        public DateTime DataInicio { get; set; }
        [Required]
        public DateTime DataTermino { get; set; }
        [Required]
        [Range(0, int.MaxValue, ErrorMessage = "Quantidade não pode ser menor que 0.")]
        public int Vagas { get; set; }
        [Required]
        public bool Status { get; set; }
        [JsonIgnore]
        public virtual Log Log { get; set; }
        public virtual Categoria Categoria { get; set; }
        public int CategoriaId { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            
        }
    }
}
