using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace HelpLight.Data.Models
{
    public class Volunteer
    {
        public Volunteer()
        {
            Bans = new List<Ban>();
            Applications = new List<Application>();
            AchieveVolunteers = new List<AchieveVolunteer>();
            VolunteerOrganizations = new List<VolunteerOrganization>();
            Comments = new List<Comment>();
            Curates = new List<Volunteer>();
            Skills = new List<Skill>();
        }

        [Key]
        public Guid IdVolunteer { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public bool Banned { get; set; }
        [Required]
        public DateTime Birthday { get; set; }
        public string About { get; set; }
        public string Avatar { get; set; }

        [Required]
        public Guid IdUser { get; set; } // unique

        public User User { get; set; }

        public Karma Karma { get; set; }

        public List<Ban> Bans { get; set; }

        public List<Application> Applications { get; set; }

        public Contact Contacts { get; set; }

        public string CuretedBy { get; set; }

        public List<Volunteer> Curates { get; set; }

        public LastWorkDate LastWorkDate { get; set; }
        
        public List<AchieveVolunteer> AchieveVolunteers { get; set; }

        public List<VolunteerOrganization> VolunteerOrganizations { get; set; }

        public Card Card { get; set; }

        public List<Comment> Comments { get; set; }

        public List<Skill> Skills { get; set; }

        public List<ReviewOfVolunteer> ReviewsOfVolunteer { get; set; }

        public List<VolunteerEventReview> VolunteerEventReviews { get; set; }
    }
}
