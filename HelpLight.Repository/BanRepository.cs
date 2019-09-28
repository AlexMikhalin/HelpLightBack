using HelpLight.Data.Contexts;
using HelpLight.Repository.Contracts;
using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace HelpLight.Repository
{
    public class BanRepository : IBanRepository
    {
        private readonly HelpLightDbContext _VaODbContext;
        private readonly IVolunteerReporitory _volunteerRepository;

        public BanRepository(HelpLightDbContext _VaODbContext,
                             IVolunteerReporitory _volunteerRepository)
        {
            this._VaODbContext = _VaODbContext;
            this._volunteerRepository = _volunteerRepository;
        }

        public void BanVolunteerByOrganization(Ban ban)
        {
            try
            {
                var banEntity = Mapper.Map<Contracts.Ban, Ban>(ban);
                _VaODbContext.Add(banEntity);
                SaveChanges();
            }
            catch
            {
                throw;
            }
        }

        public void BanVolunteerInAllOrganizations(Guid volunteerId)
        {
            try
            {
                var vol = _volunteerRepository.GetVolunteerEntity(volunteerId);
                vol.Banned = true;
                SaveChanges();
            }
            catch
            {
                throw;
            }
        }

        public List<Contracts.Volunteer> GetAllBannedVolunteersByOrganizationId(Guid organizationId)
        {
            try
            {
                //var volunteersEntities = _VaODbContext.Volunteers.Where(v => v.Bans.Any());

                var b = _VaODbContext.Bans.Where(c => c.IdOrganization == organizationId).ToList();
                return new List<Volunteer>();
            }
            catch
            {
                throw;
            }
        }

        public void UnBanVolunteerByOrganizationId(Guid volunteerId, Guid orgId)
        {
            try
            {
                var deletingBan = _VaODbContext.Bans
                                            .Where(b => b.IdVolunteer == volunteerId && b.IdOrganization == orgId)
                                            .FirstOrDefault(); 

                _VaODbContext.Remove(deletingBan);
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
