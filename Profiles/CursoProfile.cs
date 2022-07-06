using AutoMapper;
using CastCursos.Data.Dtos;
using CastCursos.Models;

namespace CastCursos.Profiles
{
    public class CursoProfile : Profile
    {
        public CursoProfile()
        {
            CreateMap<CreateCursoDto, Curso>();
            CreateMap<UpdateCursoDto, Curso>();
            CreateMap<Curso, ReadCursoDto>();
        }
    }
}
