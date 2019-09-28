using System;
using System.Collections.Generic;
using System.Text;

namespace HelpLight.Repository.Contracts
{
    public interface IReviewOfVolunteerRepository : IWorkUnit
    {
        List<ReviewOfVolunteer> GetReviewsOfVolunteer(Guid volunteerId);
        void AddReviewOfVolunteer(ReviewOfVolunteer reviewOfVolunteer);
    }
}
