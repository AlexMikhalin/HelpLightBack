using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;

namespace HelpLight.Repository.Convertors
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<Data.Models.User, Contracts.User>()
                .ReverseMap();
        }
    }
}
