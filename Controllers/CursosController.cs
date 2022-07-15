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
            var curso = _mapper.Map<Curso>(cursoDto); // mapeia as informações da requisição para a classe modelo
            var cursosPorData = _context.Cursos.Where(c => ((curso.DataInicio >= c.DataInicio && curso.DataInicio <= c.DataTermino) ||
                                                     (curso.DataTermino >= c.DataInicio && curso.DataTermino <= c.DataTermino) ||
                                                     (c.DataInicio >= curso.DataInicio && c.DataInicio <= curso.DataTermino)) &&
                                                     (c.Status == true)); // seleção no banco de dados para garantir que não haja curso dentro deste período

            var cursoPorNome = _context.Cursos.Where(c => curso.Nome == c.Nome && c.Status == true);

            if (cursosPorData.Count() > 0)
            {
                return StatusCode(400, "Existe(m) curso(s) planejados(s) dentro do período informado.");
            } else if (cursoPorNome.Count() > 0)
            {
                return StatusCode(400, "Curso já cadastrado.");
            }
            
            if (curso.DataInicio >= DateTime.Now || curso.DataInicio <= curso.DataTermino)
            {
                curso.Status = true;
                _context.Cursos.Add(curso);
                _context.SaveChanges();

                var logDto = new CreateLogDto
                {
                    CursoId = curso.Id,
                    DataCriacao = DateTime.Now.Date,
                    DataModificacao = null
                };

                var log = _mapper.Map<Log>(logDto);
                _context.Log.Add(log);
                _context.SaveChanges();

                return CreatedAtAction(nameof(RecuperaPorId), new { Id = curso.Id }, curso);
            }
            
            return StatusCode(400, "Data inválida.");
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

            if (curso != null)
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
                return NotFound("Curso não encontrado.");
            }
            
            _mapper.Map(cursoDto, curso);

            var cursosPorData = _context.Cursos.Where(c => ((curso.DataInicio >= c.DataInicio && curso.DataInicio <= c.DataTermino) ||
                                                     (curso.DataTermino >= c.DataInicio && curso.DataTermino <= c.DataTermino) ||
                                                     (c.DataInicio >= curso.DataInicio && c.DataInicio <= curso.DataTermino)) &&
                                                     (c.Status == true && curso.Id != c.Id));

            if (cursosPorData.Count() > 0)
            {
                return StatusCode(400, "Existe(m) curso(s) planejados(s) dentro do período informado.");
            }

            var log = _context.Log.FirstOrDefault(log => log.CursoId == id);
            log.DataModificacao = DateTime.Now.Date;

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
            } else if (curso.DataTermino <= DateTime.Now)
            {
                return StatusCode(400, "Não é possível deletar um curso iniciado ou já finalizado.");
            }

            curso.Status = false;
            _context.SaveChanges();
            return NoContent();
        }
    }
}
