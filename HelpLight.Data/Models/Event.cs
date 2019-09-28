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
        }

        [Key]
        public Guid IdEvent { get; set; }
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
        public string WorkDescription { get; set; }

        public string Poster { get; set; }

        public PeopleRequired[] PeopleRequired { get; set; }
        [Required]
        public int Tokens { get; set; }

        public Applies Applies { get; set; }

        [Required]
        public Guid IdOrganization { get; set; }
        public Organization Organization { get; set; }

        public List<Application> Applications { get; set; }
    }
}
