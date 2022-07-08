using System.ComponentModel.DataAnnotations;
using CastCursos.Models;

namespace CastCursos.Data.Dtos
{
    public class ReadCursoDto
    {
        [Key]
        [Required]
        public int Id { get; internal set; }
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
        public Categoria Categoria { get;set; }
    }
}
