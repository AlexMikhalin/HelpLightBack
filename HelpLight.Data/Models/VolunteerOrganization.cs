using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace HelpLight.Data.Models
{
    public class VolunteerOrganization
    {
        public Guid IdVolunteer { get; set; }
        public Volunteer Volunteer { get; set; }

        public Guid IdOrganization { get; set; }
        public Organization Organization { get; set; }
    }
}
