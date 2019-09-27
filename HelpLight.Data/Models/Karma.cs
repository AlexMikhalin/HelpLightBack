using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace HelpLight.Data.Models
{
    public class Karma
    {
        public Karma()
        {
            KarmaHistory = new List<KarmaHistory>();
        }

        public Karma(Guid volunteerId)
        {
            KarmaHistory = new List<KarmaHistory>();
            IdVolunteer = volunteerId;
            TotalScore = 0;
        }

        [Key]
        public Guid IdKarma { get; set; }
        public int TotalScore { get; set; }

        public Guid IdVolunteer { get; set; }
        public Volunteer Volunteer { get; set; }
        public List<KarmaHistory> KarmaHistory { get; set; }
    }
}
