using AutoMapper;
using PlatformService.DTOs;
using PlatformService.Models;

namespace PlatformService.Profiles
{
    public class PlatformProfile : Profile
    {
        public PlatformProfile()
        {
            //Source -> target
            CreateMap<Platform,PlaformReadDto>();
            CreateMap<Platform,PlaformCreateDto>();
        }
    }
}