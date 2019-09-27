using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace HelpLight.Data.Models
{
    public class Organization
    {
        public Organization()
        {
            Events = new List<Event>();
            VolunteerOrganizations = new List<VolunteerOrganization>();
            WallRecords = new List<WallRecord>();
        }

        [Key]
        public Guid IdOrganization { get; set; }
        [Required]
        public string OrganizationName { get; set; }
        [Required]
        public string Address { get; set; }

        public Guid IdUser { get; set; } // unique
        public User User { get; set; }
        public List<Event> Events { get; set; }

        public List<VolunteerOrganization> VolunteerOrganizations { get; set; }
        public List<WallRecord> WallRecords { get; set; }
    }
}
