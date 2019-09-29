using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace HelpLight.Data.Models
{
    public class VolunteerEventReview
    {
        [Key]
        public Guid IdVolunteerEventReview { get; set; }

        public string Review { get; set; }
        public int Rating { get; set; }

        public Guid IdEvent { get; set; }

        public Guid IdVolunteer { get; set; }
        public Volunteer Volunteer { get; set; }
    }
}
