using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace HelpLight.Data.Models
{
    public class Event
    {
        public Event()
        {
            Applications = new List<Application>();
            PeopleRequired = new List<PeopleRequired>();
        }

        [Key]
        public Guid IdEvent { get; set; }
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
        public string Title { get; set; }
        public string WorkDescription { get; set; }
        public string Poster { get; set; }

        public List<PeopleRequired> PeopleRequired { get; set; }

        [Required]
        public int Tokens { get; set; }

        [Required]
        public Guid IdOrganization { get; set; }
        public Organization Organization { get; set; }

        public List<Application> Applications { get; set; }
    }
}
