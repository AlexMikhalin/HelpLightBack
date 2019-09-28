using System;
using System.Collections.Generic;
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
        public string Name { get; set; }
        public string Avatar { get; set; }
        public string Email { get; set; }
        public string Desc { get; set; }
        public string Title { get; set; }
        public string City { get; set; }
        public string Tags { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public int Balance { get; set; }

        public Guid IdUser { get; set; } // unique
        public User User { get; set; }
        public List<Event> Events { get; set; }

        public List<VolunteerOrganization> VolunteerOrganizations { get; set; }
        public List<WallRecord> WallRecords { get; set; }

        public List<Ban> Bans { get; set; }
    }
}
