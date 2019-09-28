using System;
using System.Collections.Generic;
using System.Text;

namespace HelpLight.Repository.Contracts
{
    public interface IEventRepository : IWorkUnit
    {
        void CreateEvent(Event newEvent);
        void UpdateEvent(Event updatingEvent);
        void DeleteEvent(Guid eventId);
        List<Event> GetAllEventsByOrganizationId(Guid orgId);
        //List<Volunteer> GetVolunteersAppliedForEvent(Guid eventId, bool onlyApproved = false);
        List<Contracts.Event> GetAllEvents();
        List<Contracts.Event> GetAllEventsByVolunteerId(Guid volunteerId);
    }
}
