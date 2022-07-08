using CastCursos.Models;
using Microsoft.EntityFrameworkCore;

namespace CastCursos.Data
{
    public class Context : DbContext
    {
        public DbSet<Curso> Cursos { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Log> Log { get; set; }

        public Context(DbContextOptions<Context> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Curso>()
                .HasOne(curso => curso.Log)
                .WithOne(log => log.Curso)
                .HasForeignKey<Log>(log => log.CursoId);

            modelBuilder.Entity<Curso>()
                .HasOne(curso => curso.Categoria)
                .WithMany(categoria => categoria.Cursos)
                .HasForeignKey(curso => curso.CategoriaId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
