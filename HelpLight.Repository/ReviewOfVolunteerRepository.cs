using HelpLight.Data.Contexts;
using HelpLight.Data.Models;
using HelpLight.Repository.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using ReviewOfVolunteer = HelpLight.Data.Models.ReviewOfVolunteer;
using AutoMapper;

namespace HelpLight.Repository
{
    public class ReviewOfVolunteerRepository : IReviewOfVolunteerRepository
    {
        private readonly HelpLightDbContext _VaODbContext;

        public ReviewOfVolunteerRepository(HelpLightDbContext HelpLightDbContext)
        {
            this._VaODbContext = HelpLightDbContext;
        }

        public void AddReviewOfVolunteer(Contracts.ReviewOfVolunteer reviewOfVolunteer)
        {
            try
            {
                var reviewEntity = Mapper.Map<Contracts.ReviewOfVolunteer, ReviewOfVolunteer>(reviewOfVolunteer);
                _VaODbContext.ReviewsOfVolunteers.Add(reviewEntity);

                var karma = _VaODbContext.Karmas.Where(k => k.IdVolunteer == reviewOfVolunteer.IdVolunteer).FirstOrDefault();
                karma.TotalScore += reviewOfVolunteer.Stars;

                SaveChanges();
            }
            catch
            {
                throw;
            }
        }

        public List<Contracts.ReviewOfVolunteer> GetReviewsOfVolunteer(Guid volunteerId)
        {
            try
            {
                var reviewsEntities = _VaODbContext.ReviewsOfVolunteers.Where(r => r.IdVolunteer == volunteerId).ToList();
                var reviws = Mapper.Map<List<Contracts.ReviewOfVolunteer>>(reviewsEntities);
                return reviws;
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
