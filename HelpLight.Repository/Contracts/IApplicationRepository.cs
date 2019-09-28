using System;
using System.Collections.Generic;
using System.Text;

namespace HelpLight.Repository.Contracts
{
    public interface IApplicationRepository : IWorkUnit
    {
        void CreateApplication(Contracts.Application application);
        void DeleteApplication(Guid applicationId);
        void UpdateApplication(Contracts.Application application); // should be available for volunteer only
        void ApproveApplication(Guid applicationId);
        void RejectApplication(Guid applicationId);
        List<Application> GetApplicationsByVolunteerId(Guid volunteerId); // this one should be available for this volunteer
        void RecallApplication(Guid applicationId);
    }
}
