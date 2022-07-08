using AutoMapper;
using CastCursos.Data.Dtos.Logs;
using CastCursos.Models;

namespace CastCursos.Profiles
{
    public class LogProfile : Profile
    {
        public LogProfile()
        {
            CreateMap<CreateLogDto, Log>();
            CreateMap<Log, ReadLogDto>();
        }
    }
}
