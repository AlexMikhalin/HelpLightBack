using HelpLight.Data.Contexts;
using HelpLight.Data.Models;
using HelpLight.Repository.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using Event = HelpLight.Data.Models.Event;
using AutoMapper;

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

        List<Contracts.Volunteer> IEventRepository.GetVolunteersAppliedForEvent(Guid eventId, bool onlyApproved)
        {
            throw new NotImplementedException();
        }
    }
}
