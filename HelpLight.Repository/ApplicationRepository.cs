using System;
using System.Collections.Generic;
using System.Linq;
using Application = HelpLight.Data.Models.Application;
using AutoMapper;
using HelpLight.Repository.Contracts;
using HelpLight.Data.Contexts;
using Microsoft.EntityFrameworkCore;

namespace HelpLight.Repository
{
    public class ApplicationRepository : IApplicationRepository
    {
        private readonly HelpLightDbContext _VaODbContext;

        public ApplicationRepository(HelpLightDbContext OrganizationsAndVolunteersDbContext)
        {
            this._VaODbContext = OrganizationsAndVolunteersDbContext;
        }

        private Application GetApplicationEntity(Guid applicationId)
        {
            var application = new Application();
            try
            {
                application = _VaODbContext.Applications.Where(a => a.IdApplication == applicationId).FirstOrDefault();
            }
            catch
            {
                throw;
            }
            return application;
        }

        public void ApproveApplication(Guid applicationId)
        {
            try
            {
                var approvingApplication = GetApplicationEntity(applicationId);
                approvingApplication.Rejected = false;
                approvingApplication.Approved = true;
                SaveChanges();
            }
            catch
            {
                throw;
            }
        }

        public void CreateApplication(Contracts.Application application)
        {
            try
            {
                var appEntity = Mapper.Map<Contracts.Application, Application>(application);
                _VaODbContext.Add(appEntity);
                SaveChanges();
            }
            catch
            {
                throw;
            }
        }

        public void DeleteApplication(Guid applicationId)
        {
            try
            {
                var deletingApplication = _VaODbContext.Applications.Where(a => a.IdApplication == applicationId).FirstOrDefault();
                _VaODbContext.Remove(deletingApplication);
                SaveChanges();
            }
            catch
            {
                throw;
            }
        }

        public void RejectApplication(Guid applicationId)
        {
            try
            {
                var rejectingApplication = GetApplicationEntity(applicationId);
                rejectingApplication.Rejected = true;
                rejectingApplication.Approved = false;
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

        public void UpdateApplication(Contracts.Application application)
        {
            try
            {
                var updatingApplication = GetApplicationEntity(application.IdApplication);

                updatingApplication.VolunteerComment = application.VolunteerComment;
                SaveChanges();
            }
            catch
            {
                throw;
            }
        }

        public List<Contracts.Application> GetApplicationsByVolunteerId(Guid volunteerId)
        {
            var applications = new List<Contracts.Application>();
            try
            {
                var applicationEntities = _VaODbContext.Applications
                                                        .Where(a => a.IdVolunteer == volunteerId)
                                                        .ToList();
                applications = Mapper.Map<List<Contracts.Application>>(applicationEntities);
            }
            catch
            {
                throw;
            }
            return applications;
        }

        public void RecallApplication(Guid applicationId)
        {
            try
            {
                var recalingApplication = GetApplicationEntity(applicationId);

                recalingApplication.Recalled = true;
                recalingApplication.Rejected = false;
                recalingApplication.Approved = false;

                SaveChanges();
            }
            catch
            {
                throw;
            }
        }

        public void WasOnEvent(Guid applicationId)
        {
            try
            {
                var application = GetApplicationEntity(applicationId);

                application.WasOnEnent = true;

                SaveChanges();
            }
            catch
            {
                throw;
            }
        }

        public List<Contracts.Application> GetApplicationsByEventId(Guid eventId)
        {
            try
            {
                var apps = _VaODbContext.Applications.Where(a => a.IdEvent == eventId).Include(t => t.Volunteer).ToList();
                return Mapper.Map<List<Contracts.Application>>(apps);
            }
            catch
            {
                throw;
            }
        }
    }
}
