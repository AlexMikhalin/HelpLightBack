using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace HelpLight.Repository.Contracts
{
    public class Karma
    {
        public Karma(Guid volunteerId)
        {
            IdVolunteer = volunteerId;
            TotalScore = 0;
        }

        [Required]
        public Guid IdKarma { get; set; }
        public int TotalScore { get; set; }

        public Guid IdVolunteer { get; set; }
    }
}
