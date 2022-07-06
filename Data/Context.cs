using CastCursos.Models;
using Microsoft.EntityFrameworkCore;

namespace CastCursos.Data
{
    public class Context : DbContext
    {
        public DbSet<Curso> Cursos { get; set; }

        public Context(DbContextOptions<Context> options) : base(options)
        {
        }


    }
}
