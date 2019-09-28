using HelpLight.Data.Contexts;
using HelpLight.Repository.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

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

        public void BanVolunteerByOrganizationId(Guid volunteerId, Guid organizationId)
        {
            throw new NotImplementedException();
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
            throw new NotImplementedException();
        }

        public void SaveChanges()
        {
            _VaODbContext.SaveChanges();
        }

        public void UnBanVolunteerByOrganizationId(Guid volunteerId, Guid orgId)
        {
            throw new NotImplementedException();
        }
    }
}
