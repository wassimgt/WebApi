using AutoMapper;
using WebApi.DTO;
using WebApi.entites;

namespace WebApi.Helper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<genreDTO,genre>().ReverseMap();
            CreateMap<genrecreateDTO, genre >();
        }
    }
}
