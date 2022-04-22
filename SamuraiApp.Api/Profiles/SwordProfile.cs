using AutoMapper;
using SamuraiApp.Api.DTO;
using SamuraiApp.Domain;

namespace SamuraiApp.Api.Profiles
{
    public class SwordProfile : Profile
    {
        public SwordProfile()
        {
            CreateMap<Sword, SwordDTO>();
            //CreateMap<SwordCreateDTO, Sword>();
            CreateMap<SwordCreateWithElementDTO, Sword>();
            CreateMap<ElementDTO, Element>();
            CreateMap<SwordCreateDTO, Sword>();
        }
    }
}
