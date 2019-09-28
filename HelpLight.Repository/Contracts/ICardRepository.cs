using System;
using System.Collections.Generic;
using System.Text;

namespace HelpLight.Repository.Contracts
{
    public interface ICardRepository : IWorkUnit
    {
        Contracts.Card GetCardByVolunteerId(Guid volunteerId);
        void AddCardToVolunteer(Guid volunteerId, Contracts.Card card);
    }
}
