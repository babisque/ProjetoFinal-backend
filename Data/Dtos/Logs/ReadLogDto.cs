using CastCursos.Models;

namespace CastCursos.Data.Dtos.Logs
{
    public class ReadLogDto
    {
        public Curso Curso { get; set; }
        public DateTime DataCriacao { get; set; }
        public DateTime DataModificacao { get; set; }
    }
}
