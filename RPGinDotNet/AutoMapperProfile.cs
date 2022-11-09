using AutoMapper;
using RPGinDotNet.Dtos.Character;
using RPGinDotNet.Models;

namespace RPGinDotNet
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Character, GetCharacterDto>();
            CreateMap<AddCharacterDto, Character>();
            CreateMap<UpdateCharacterDto, Character>();
        }
    }
}
