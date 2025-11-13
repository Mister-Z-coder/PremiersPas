using AutoMapper;
using BackendAPI.DTOs;
using BackendAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackendAPI.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Ecole, EcoleDto>().ReverseMap();

            CreateMap<Eleve, EleveDto>().ReverseMap();

            CreateMap<Annee_Scolaire, Annee_ScolaireDto>().ReverseMap();

            CreateMap<Inscription, InscriptionDto>().ReverseMap();
        }
    }
}
