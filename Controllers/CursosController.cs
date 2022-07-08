using AutoMapper;
using CastCursos.Data;
using CastCursos.Data.Dtos;
using CastCursos.Data.Dtos.Logs;
using CastCursos.Models;
using Microsoft.AspNetCore.Mvc;

namespace CastCursos.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CursosController : ControllerBase
    {
        private Context _context;
        private IMapper _mapper;

        public CursosController(Context context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpPost]
        public IActionResult AdicionaCurso([FromBody] CreateCursoDto cursoDto)
        {
            var curso = _mapper.Map<Curso>(cursoDto);
            curso.Status = true;
            _context.Cursos.Add(curso);
            _context.SaveChanges();

            var logDto = new CreateLogDto
            {
                CursoId = curso.Id,
                DataCriacao = DateTime.Now,
                DataModificacao = null
            };

            var log = _mapper.Map<Log>(logDto);
            _context.Log.Add(log);
            _context.SaveChanges();

            return CreatedAtAction(nameof(RecuperaPorId), new { Id = curso.Id }, curso);
        }

        [HttpGet]
        public IActionResult RecuperaCursos()
        {
            var cursos = _context.Cursos.Where(curso => curso.Status == true).ToList();
            
            if (cursos != null)
            {
                var cursosDto = _mapper.Map<List<ReadCursoDto>>(cursos);
                return Ok(cursosDto);
            }

            return NotFound();
        }

        [HttpGet("{id}")]
        public IActionResult RecuperaPorId(int id)
        {
            var curso = _context.Cursos.FirstOrDefault(curso => curso.Id == id);

            if(curso != null)
            {
                ReadCursoDto cursoDto = _mapper.Map<ReadCursoDto>(curso);
                return Ok(cursoDto);
            }

            return NotFound();
        }

        [HttpPut("{id}")]
        public IActionResult AtualizaCurso(int id, [FromBody] UpdateCursoDto cursoDto)
        {
            var curso = _context.Cursos.FirstOrDefault(curso => curso.Id == id);
            if (curso == null)
            {
                return NotFound();
            }
            _mapper.Map(cursoDto, curso);
            _context.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeletaCurso(int id)
        {
            var curso = _context.Cursos.FirstOrDefault(curso => curso.Id == id);
            if (curso == null)
            {
                return NotFound();
            }
            _context.Remove(curso);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
