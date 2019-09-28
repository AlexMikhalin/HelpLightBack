using HelpLight.Data.Contexts;
using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using System.Linq;
using WallRecord = HelpLight.Data.Models.WallRecord;
using HelpLight.Repository.Contracts;
using Microsoft.EntityFrameworkCore;

namespace HelpLight.Repository
{
    public class VolunteerOrganizationRepository : IVolunteerOrganizationRepository
    {
        private readonly HelpLightDbContext _VaODbContext;

        public VolunteerOrganizationRepository(HelpLightDbContext _VaODbContext)
        {
            this._VaODbContext = _VaODbContext;
        }

        public List<Contracts.Volunteer> GetVolunteersByOrganization(Guid organizationId)
        {
            try
            {
                var xc = _VaODbContext.Volunteers
                                      .Where(v => v.VolunteerOrganizations
                                                    .Any(vo => vo.IdOrganization == organizationId))
                                      .ToList();
                var ovs = Mapper.Map<List<Contracts.Volunteer>>(xc);
                return ovs;
            }
            catch
            {
                throw;
            }
        }

        public List<Contracts.Organization> GetOrganizationsByVolunteer(Guid volunteerId)
        {
            try
            {
                var xc = _VaODbContext.Organizations
                                      .Where(v => v.VolunteerOrganizations
                                                    .Any(vo => vo.IdVolunteer == volunteerId))
                                      .ToList();
                var ovs = Mapper.Map<List<Contracts.Organization>>(xc);
                return ovs;
            }
            catch
            {
                throw;
            }
        }

        public void JoinOrganization(Guid organizationId, Guid volunteerId)
        {
            try
            {
                var org = _VaODbContext.VolunteerOrganizations
                                        .Add(new Data.Models.VolunteerOrganization()
                                        {
                                            IdOrganization = organizationId,
                                            IdVolunteer = volunteerId
                                        });
                SaveChanges();
            }
            catch (Exception)
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
