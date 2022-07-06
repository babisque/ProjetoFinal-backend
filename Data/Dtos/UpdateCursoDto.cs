using System.ComponentModel.DataAnnotations;

namespace CastCursos.Data.Dtos
{
    public class UpdateCursoDto
    {
        [Required]
        public string Nome { get; set; }
        [Required]
        public string Descricao { get; set; }
        [Required]
        public DateTime DataInicio { get; set; }
        [Required]
        public DateTime DataTermino { get; set; }
        [Required]
        [Range(0, int.MaxValue, ErrorMessage = "Quantidade não pode ser menor que 0.")]
        public int Vagas { get; set; }
        [Required]
        public string Categoria { get; set; }
    }
}
