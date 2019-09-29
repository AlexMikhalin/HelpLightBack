using System;
using System.Collections.Generic;
using System.Text;

namespace HelpLight.Repository.Contracts
{
    public interface IVolunteerEventReviewRepository : IWorkUnit
    {
        void ReviewEvent(VolunteerEventReview review);
        List<VolunteerEventReview> GetEventReviews(Guid eventId);
    }
}
