using AutoMapper;

namespace hello_world_demo.Model.AutoMapper
{
    public class GatoMapper : Profile
    {
        public GatoMapper()
        {
            CreateMap<Gato, GatoDto>();
        }
    }
}