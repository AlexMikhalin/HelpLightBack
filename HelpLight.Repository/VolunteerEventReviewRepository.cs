using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HelpLight.Data.Contexts;
using HelpLight.Repository.Contracts;
using Microsoft.EntityFrameworkCore;
using AutoMapper;

namespace HelpLight.Repository
{
    public class VolunteerEventReviewRepository : IVolunteerEventReviewRepository
    {
        private readonly HelpLightDbContext _VaODbContext;

        public VolunteerEventReviewRepository(HelpLightDbContext _VaODbContext)
        {
            this._VaODbContext = _VaODbContext;
        }

        public List<VolunteerEventReview> GetEventReviews(Guid eventId)
        {
            try
            {
                var reviews = _VaODbContext.VolunteerEventReviews
                                        .Where(r => r.IdVolunteer == eventId)
                                        .Include(v => v.Volunteer).ToList();

                return Mapper.Map<List<Contracts.VolunteerEventReview>>(reviews);
            }
            catch
            {
                throw;
            }
        }

        public void ReviewEvent(VolunteerEventReview review)
        {
            try
            {
                var reviewEntity = Mapper.Map<Contracts.VolunteerEventReview, Data.Models.VolunteerEventReview>(review);
                _VaODbContext.VolunteerEventReviews.Add(reviewEntity);
                SaveChanges();
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
