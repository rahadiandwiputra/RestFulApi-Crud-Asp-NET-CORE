
using AutoMapper;
using SamuraiApp.Api.DTO;
using SamuraiApp.Domain;

namespace SamuraiApp.Api.Profiles
{
    public class SamuraiProfile : Profile
    {
        public SamuraiProfile()
        {
            CreateMap<Samurai, SamuraiDTO>();
            CreateMap<SamuraiCreateDTO, Samurai>();
            CreateMap<SamuraiCreateWithSwordDTO, Samurai>();
            CreateMap<Samurai, SamuraiReadWithSword>();
            CreateMap<Samurai, SamuraiSwordElementReadDTO>();   
            CreateMap<Samurai, SamuraiReadSEDTO>();

        }
    }
}

