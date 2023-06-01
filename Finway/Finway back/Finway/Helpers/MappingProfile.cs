using AutoMapper;
using Finway.Models;
using Finway.Models.DTO;
using System;

namespace Finway.Helpers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Person, PersonDto>().ReverseMap();
        }
    }
}
