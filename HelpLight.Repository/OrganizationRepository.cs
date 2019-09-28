using HelpLight.Data.Contexts;
using HelpLight.Data.Models;
using HelpLight.Repository.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Organization = HelpLight.Data.Models.Organization;
using AutoMapper;

namespace HelpLight.Repository
{
    public class OrganizationRepository : IOrganizationRepository
    {
        private readonly HelpLightDbContext _HelpLightDbContext;

        public OrganizationRepository(HelpLightDbContext HelpLightDbContext)
        {
            this._HelpLightDbContext = HelpLightDbContext;
        }

        public Contracts.Organization GetOrganizationInfoById(Guid id)
        {
            try
            {
                var org = GetOrganizationEntity(id);

                var orgShort = Mapper.Map<Contracts.Organization>(org);
                return orgShort;
            }
            catch
            {
                throw;
            }
        }

        public Organization GetOrganizationEntity(Guid id)
        {
            try
            {
                var organization = _HelpLightDbContext.Organizations
                                            .Where(org => org.IdOrganization == id)
                                            .FirstOrDefault();
                if (organization == null)
                {
                    throw new Exception("Organization with requested id not found");
                }

                return organization;
            }
            catch
            {
                throw;
            }
        }

        public void SaveChanges()
        {
            _HelpLightDbContext.SaveChanges();
        }

        // TODO: critical
        // update by UserId
        public void UpdateOrganizationInfo(Contracts.Organization orgInfo)
        {
            try
            {
                var updatingOrgEntity = GetOrganizationEntity(orgInfo.IdOrganization);

                Mapper.Map(orgInfo, updatingOrgEntity);
                SaveChanges();
            }
            catch
            {
                throw;
            }
        }
    }
}
