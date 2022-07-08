using AutoMapper;
using CastCursos.Data;
using CastCursos.Data.Dtos.Logs;
using CastCursos.Models;
using Microsoft.AspNetCore.Mvc;

namespace CastCursos.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LogsController : ControllerBase
    {
        private Context _context;
        private IMapper _mapper;

        public LogsController(Context context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpPost]
        public IActionResult AdicionaLog([FromBody] CreateLogDto logDto)
        {
            var log = _mapper.Map<Log>(logDto);
            _context.Log.Add(log);
            _context.SaveChanges();
            return CreatedAtAction(nameof(RecuperaPorId), new { Id = log.Id }, log);
        }

        [HttpGet("{id}")]
        public IActionResult RecuperaPorId(int id)
        {
            var log = _context.Log.FirstOrDefault(l => l.Id == id);
            if (log != null)
            {
                var logDto = _mapper.Map<ReadLogDto>(log);
                return Ok(logDto);
            }

            return NotFound();
        }

        [HttpGet]
        public IActionResult RecuperaLogs()
        {
            var logs = _context.Log.ToList();

            if (logs != null)
            {
                var logsDto = _mapper.Map<List<ReadLogDto>>(logs);
                return Ok(logsDto);
            }

            return NotFound();
        }
    }
}
