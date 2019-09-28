using System;
using System.Collections.Generic;
using System.Text;

namespace HelpLight.Repository.Contracts
{
    public interface IKarmaRepository : IWorkUnit
    {
        List<KarmaHistory> GetMyKarmaHistory(Guid volunteerId);
        void AddKarma(Guid volunteerId, int score, string reason = null, Guid? eventId = null);
    }
}
