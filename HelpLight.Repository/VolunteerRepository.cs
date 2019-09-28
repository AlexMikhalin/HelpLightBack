using AutoMapper;
using HelpLight.Data.Contexts;
using HelpLight.Repository.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using Volunteer = HelpLight.Data.Models.Volunteer;

namespace HelpLight.Repository
{
    public class VolunteerRepository : IVolunteerReporitory
    {
        private readonly HelpLightDbContext _VaODbContext;

        public VolunteerRepository(HelpLightDbContext HelpLightDbContext)
        {
            this._VaODbContext = HelpLightDbContext;
        }

        public Contracts.Volunteer GetVolunteerInfoById(Guid id)
        {
            try
            {
                var volunteer = GetVolunteerEntity(id);

                var volunteerShort = Mapper.Map<Contracts.Volunteer>(volunteer);
                return volunteerShort;
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

        public void UpdadeVolunteerInfo(Contracts.Volunteer volunteer)
        {
            try
            {
                var updatingVolunteerEntity = GetVolunteerEntity(volunteer.IdVolunteer);

                Mapper.Map(volunteer, updatingVolunteerEntity);
                SaveChanges();
            }
            catch
            {
                throw;
            }
        }

        public Volunteer GetVolunteerEntity(Guid id)
        {
            try
            {
                var volunteer = _VaODbContext.Volunteers
                                                    .Where(v => v.IdVolunteer == id)
                                                    .FirstOrDefault();
                if (volunteer == null)
                {
                    throw new Exception("Volunteer with requested id not found");
                }

                return volunteer;
            }
            catch
            {
                throw;
            }
        }

    }
}
