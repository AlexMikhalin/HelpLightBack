using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace HelpLight.Data.Models
{
    public class Application
    {
        [Key]
        public Guid IdApplication { get; set; }
        public bool Approved { get; set; }
        public bool Rejected { get; set; }
        public bool Recalled { get; set; }

        public bool WasOnEnent { get; set; }
        public string VolunteerComment { get; set; }
        public string OrganizationComment { get; set; }

        [Required]
        public Guid IdVolunteer { get; set; }
        public Volunteer Volunteer { get; set; }

        [Required]
        public Guid IdEvent { get; set; } // unique
        public Event Event { get; set; }
    }
}
