using System;
using System.Collections.Generic;
using System.Text;

namespace HelpLight.Repository.Contracts
{
    public interface IOrganizationRepository : IWorkUnit
    {
        Organization GetOrganizationInfoById(Guid id);
        void UpdateOrganizationInfo(Organization Organization);
        void ValidateOrganization(Guid userId, Guid organizationId);
    }
}
