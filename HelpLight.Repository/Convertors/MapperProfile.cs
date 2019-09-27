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

            CreateMap<Data.Models.Volunteer, Contracts.Volunteer>()
                .ReverseMap();

            CreateMap<Data.Models.Organization, Contracts.Organization>()
                .ReverseMap();

            CreateMap<Data.Models.Achieve, Contracts.Achieve>()
                .ReverseMap();

            CreateMap<Data.Models.AchieveVolunteer, Contracts.AchieveVolunteer>()
                .ReverseMap();

            CreateMap<Data.Models.Application, Contracts.Application>()
                .ReverseMap();

            CreateMap<Data.Models.Ban, Contracts.Ban>()
                .ReverseMap();

            CreateMap<Data.Models.Card, Contracts.Card>()
                .ReverseMap();

            CreateMap<Data.Models.Comment, Contracts.Comment>()
                .ReverseMap();

            CreateMap<Data.Models.Event, Contracts.Event>()
                .ReverseMap();

            CreateMap<Data.Models.Karma, Contracts.Karma>()
                .ReverseMap();

            CreateMap<Data.Models.KarmaHistory, Contracts.KarmaHistory>()
                .ReverseMap();

            CreateMap<Data.Models.LastWorkDate, Contracts.LastWorkDate>()
                .ReverseMap();

            CreateMap<Data.Models.WallRecord, Contracts.WallRecord>()
                .ReverseMap();

            CreateMap<Data.Models.ReviewOfVolunteer, Contracts.ReviewOfVolunteer>()
                .ReverseMap();
        }
    }
}
