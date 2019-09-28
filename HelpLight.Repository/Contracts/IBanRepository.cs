using System;
using System.Collections.Generic;
using System.Text;

namespace HelpLight.Repository.Contracts
{
    public interface IBanRepository : IWorkUnit
    {
        void BanVolunteerByOrganization(Ban ban);
        void BanVolunteerInAllOrganizations(Guid volunteerId);
        void UnBanVolunteerByOrganizationId(Guid volunteerId, Guid organizationId);
        List<Volunteer> GetAllBannedVolunteersByOrganizationId(Guid organizationId);
    }
}
