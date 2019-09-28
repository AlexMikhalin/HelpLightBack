using System;
using System.Collections.Generic;
using System.Text;

namespace HelpLight.Repository.Contracts
{
    public interface IVolunteerOrganizationRepository : IWorkUnit
    {
        void JoinOrganization(Guid organizationId, Guid volunteerId);
        List<Volunteer> GetVolunteersByOrganization(Guid organizationId);
        List<Contracts.Organization> GetOrganizationsByVolunteer(Guid volunteerId);
    }
}
