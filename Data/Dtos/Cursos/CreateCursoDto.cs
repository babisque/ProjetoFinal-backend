using CastCursos.Models;
using System.ComponentModel.DataAnnotations;

namespace CastCursos.Data.Dtos
{
    public class CreateCursoDto
    {
        [Required]
        public string Nome { get; set; }
        [Required]
        public DateTime DataInicio { get; set; }
        [Required]
        public DateTime DataTermino { get; set; }
        [Required]
        [Range(0, int.MaxValue, ErrorMessage = "Quantidade não pode ser menor que 0.")]
        public int Vagas { get; set; } = 0;
        [Required]
        public int CategoriaId { get; set; }
    }
}
