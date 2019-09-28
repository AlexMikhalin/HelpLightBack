using Microsoft.EntityFrameworkCore;
using HelpLight.Data.Contexts;
using HelpLight.Data.Models;
using HelpLight.Repository.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using KarmaHistory = HelpLight.Data.Models.KarmaHistory;
using AutoMapper;

namespace HelpLight.Repository
{
    public class KarmaRepository : IKarmaRepository
    {
        private readonly HelpLightDbContext _VaODbContext;
        private readonly IVolunteerReporitory _volunteerReporitory;

        public KarmaRepository(HelpLightDbContext _VaODbContext,
                               IVolunteerReporitory _volunteerReporitory)
        {
            this._VaODbContext = _VaODbContext;
            this._volunteerReporitory = _volunteerReporitory;
        }

        public void AddKarma(Guid volunteerId, int score, string reason = null, Guid? eventId = null)
        {
            try
            {
                var karma = _VaODbContext.Karmas.Where(k => k.IdVolunteer == volunteerId).FirstOrDefault();
                // TODO: Add to history
                karma.TotalScore += score;
                SaveChanges();
            }
            catch
            {
                throw;
            }
        }

        public List<Contracts.KarmaHistory> GetMyKarmaHistory(Guid volunteerId)
        {
            try
            {
                var history = GetKarmaHistoryEntityByVolunteerId(volunteerId);

                return Mapper.Map<List<Contracts.KarmaHistory>>(history);
            }
            catch
            {
                throw;
            }
        }

        private List<KarmaHistory> GetKarmaHistoryEntityByVolunteerId(Guid volunteerId)
        {
            try
            {
                var karma = _VaODbContext.Karmas.Where(k => k.IdVolunteer == volunteerId).FirstOrDefault();
                var karmaHistory = _VaODbContext.KarmaHistories.Where(kh => kh.IdKarma == karma.IdKarma).ToList();
                return karmaHistory;
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
