using CastCursos.Models;

namespace CastCursos.Data.Dtos.Categorias
{
    public class ReadCategoriaDto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public object Cursos { get; set; }
    }
}
