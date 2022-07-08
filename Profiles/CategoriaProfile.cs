using AutoMapper;
using CastCursos.Data.Dtos.Categorias;
using CastCursos.Models;

namespace CastCursos.Profiles
{
    public class CategoriaProfile : Profile
    {
        public CategoriaProfile()
        {
            CreateMap<CreateCategoriaDto, Categoria>();
            CreateMap<Categoria, ReadCategoriaDto>()
                .ForMember(categoria => categoria.Cursos, opts => opts
                .MapFrom(categoria => categoria.Cursos.Select
                (c => new { c.Id, c.Nome, c.DataInicio, c.DataTermino, c.Vagas })));
        }
    }
}
