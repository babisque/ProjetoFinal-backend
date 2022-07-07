using System.ComponentModel.DataAnnotations;

namespace CastCursos.Models
{
    public class Log
    {
        [Key]
        [Required]
        public int Id { get; set; }
        public virtual Curso Curso { get; set; }
        public int CursoId { get; set; }
        public DateTime DataCriacao { get; set; }
        public DateTime DataModificacao { get; set; }

        public override string ToString()
        {
            return $"{Id}\nCurso: {CursoId}\nData criação: {DataCriacao}\nData Modificação: {DataModificacao}";
        }
    }
}
