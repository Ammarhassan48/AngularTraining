using AutoMapper;
using CodePulse.API.Models.Domain;
using CodePulse.API.Models.DTO;

namespace CodePulse.API.Models.Mapping
{
    public class CodePulseAPIMappingProfile : Profile
    {
        
        //CreateMap<CategoryDto,Category>

        public CodePulseAPIMappingProfile()
        {
            CreateMap<CategoryDto, Category>()
                .ForMember(dest => dest.Id,
                            opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Name,
                            opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.UrlHandle,
                            opt => opt.MapFrom(src => src.UrlHandle)).ReverseMap();
        }

    }
}
