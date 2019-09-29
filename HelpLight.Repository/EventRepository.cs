using HelpLight.Data.Contexts;
using HelpLight.Data.Models;
using HelpLight.Repository.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using Event = HelpLight.Data.Models.Event;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace HelpLight.Repository
{
    public class EventRepository : IEventRepository
    {
        private readonly HelpLightDbContext _VaODbContext;

        public EventRepository(HelpLightDbContext OrganizationsAndVolunteersDbContext)
        {
            this._VaODbContext = OrganizationsAndVolunteersDbContext;
        }

        public void CreateEvent(Contracts.Event newEvent)
        {
            try
            {
                var eventEntity = Mapper.Map<Contracts.Event, Event>(newEvent);
                _VaODbContext.Add(eventEntity);
                SaveChanges();
            }
            catch
            {
                throw;
            }
        }

        public void UpdateEvent(Contracts.Event updatingEvent)
        {
            if (updatingEvent == null)
            {
                throw new Exception("Updating Event is null");
            }

            try
            {
                var oldEvent = GetEventEntity(updatingEvent.IdEvent);

                Mapper.Map(updatingEvent, oldEvent);
                SaveChanges();
            }
            catch
            {
                throw;
            }
        }

        private Event GetEventEntity(Guid id)
        {
            try
            {
                var eventEntity = _VaODbContext.Events
                                                .Where(e => e.IdEvent == id)
                                                .FirstOrDefault();
                if (eventEntity == null)
                {
                    throw new Exception("Volunteer with requested id not found");
                }

                return eventEntity;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void DeleteEvent(Guid eventId)
        {
            throw new NotImplementedException();
        }

        public List<Contracts.Event> GetAllEventsByOrganizationId(Guid idOrganization)
        {
            var events = new List<Contracts.Event>();

            try
            {
                var eventEntities = _VaODbContext.Events
                                      .Where(ev => ev.IdOrganization == idOrganization)
                                      .Include(ev => ev.PeopleRequired)
                                      .ToList();

                events = Mapper.Map<List<Contracts.Event>>(eventEntities);
            }
            catch
            {
                throw;
            }

            return events;
        }

        public void SaveChanges()
        {
            _VaODbContext.SaveChanges();
        }


        public List<Contracts.Event> GetAllEvents()
        {
            try
            {
                var events = _VaODbContext.Events.Include(e => e.PeopleRequired).Include(t => t.Applications).ToList();
                return Mapper.Map<List<Contracts.Event>>(events);
            }
            catch
            {
                throw;
            }
        }

        public List<Contracts.Event> GetAllEventsByVolunteerId(Guid volunteerId)
        {
            try
            {
                var events = _VaODbContext.Events
                            .Where(e => e.Applications.Find(a => a.IdVolunteer == volunteerId).IdVolunteer == volunteerId)
                            .ToList();

                return Mapper.Map<List<Contracts.Event>>(events);

            }
            catch
            {
                throw;
            }
        }
    }
}
