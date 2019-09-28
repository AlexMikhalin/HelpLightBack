using HelpLight.Repository.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoMapper;
using Card = HelpLight.Data.Models.Card;
using Microsoft.EntityFrameworkCore;
using HelpLight.Data.Contexts;

namespace HelpLight.Repository
{
    public class CarRepository : ICardRepository
    {
        private readonly HelpLightDbContext _VaODbContext;
        private readonly ICardRepository _cardRepository;
        private readonly IVolunteerReporitory _volunteerReporitory;

        public CarRepository(HelpLightDbContext _VaODbContext,
                             ICardRepository _cardRepository, IVolunteerReporitory _volunteerReporitory)
        {
            this._VaODbContext = _VaODbContext;
            this._cardRepository = _cardRepository;
            this._volunteerReporitory = _volunteerReporitory;
        }

        public void AddCardToVolunteer(Guid volunteerId, Contracts.Card card)
        {
            try
            {
                //var volunteerEntity = _VaODbContext.Volunteers.Where(v => v.IdVolunteer == volunteerId)
                //                                .Include(v => v.Card);

                var volunteerEntity = _volunteerReporitory.GetVolunteerEntity(volunteerId);
                var CardEntity = Mapper.Map<Card>(card);
                volunteerEntity.Card = CardEntity;
                volunteerEntity.Card.IdVolunteer = volunteerId;
                SaveChanges();
            }
            catch
            {
                throw;
            }
        }

        public Contracts.Card GetCardByVolunteerId(Guid volunteerId)
        {
            try
            {
                var card = _VaODbContext.Cards.Where(c => c.IdVolunteer == volunteerId).FirstOrDefault();
                return Mapper.Map<Contracts.Card>(card);
            }
            catch
            {
                throw;
            }
        }

        public void SaveChanges()
        {
            _VaODbContext.SaveChanges();
        }

    }
}
