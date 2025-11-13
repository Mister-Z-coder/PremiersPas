using AutoMapper;
using FrontendMVC.Models.DTOs;
using FrontendMVC.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FrontendMVC.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<EcoleViewModel, EcoleDto>()
                .ForMember(dest => dest.PhotoEcole, opt => opt.MapFrom(source => source.PhotoEcoleUrl))
                .ReverseMap()
                .ForMember(dest => dest.PhotoEcoleUrl, opt => opt.MapFrom(source => source.PhotoEcole));

            CreateMap<EleveViewModel, EleveDto>().ReverseMap();

            CreateMap<AnneeScolaireViewModel, AnneeScolaireDto>().ReverseMap();

            CreateMap<InscriptionViewModel, InscriptionDto>().ReverseMap();
        }
    }
}
