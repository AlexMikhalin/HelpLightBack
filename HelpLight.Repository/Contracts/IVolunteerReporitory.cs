using System;
using System.Collections.Generic;
using System.Text;

namespace HelpLight.Repository.Contracts
{
    public interface IVolunteerReporitory : IWorkUnit
    {
        void UpdadeVolunteerInfo(Volunteer volunteer);
        Volunteer GetVolunteerInfoById(Guid id);
        Data.Models.Volunteer GetVolunteerEntity(Guid volunteerId);
    }
}
