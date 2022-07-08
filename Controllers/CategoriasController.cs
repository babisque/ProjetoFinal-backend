﻿using AutoMapper;
using CastCursos.Data;
using CastCursos.Data.Dtos.Categorias;
using CastCursos.Models;
using Microsoft.AspNetCore.Mvc;

namespace CastCursos.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoriasController : ControllerBase
    {
        private Context _context;
        private IMapper _mapper;
        public CategoriasController(Context context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet("{id}")]
        public IActionResult RecuperaPorId(int id)
        {
            var categoria = _context.Categorias.FirstOrDefault(c => c.Id == id);
            if (categoria != null)
            {
                var categoriaDto = _mapper.Map<ReadCategoriaDto>(categoria);
                return Ok(categoriaDto);
            }

            return NotFound();
        }

        [HttpGet]
        public IActionResult RecuperaCategorias()
        {
            var categorias = _context.Categorias.ToList();
            var categoriasDto = _mapper.Map<ReadCategoriaDto>(categorias);
            return Ok(categoriasDto);
        }

        [HttpPost]
        public IActionResult AdicionaCategoria([FromBody] CreateCategoriaDto categoriaDto)
        {
            var categoria = _mapper.Map<Categoria>(categoriaDto);
            _context.Categorias.Add(categoria);
            _context.SaveChanges();
            return CreatedAtAction(nameof(RecuperaPorId), new { Id = categoria.Id }, categoria);
        }
    }
}
