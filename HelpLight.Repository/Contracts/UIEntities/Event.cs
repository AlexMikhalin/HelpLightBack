using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace HelpLight.Repository.Contracts
{
    public class Event
    {
        [Required]
        public Guid IdEvent { get; set; }
        [Required]
        public DateTime DateFrom { get; set; }
        [Required]
        public DateTime DateTo { get; set; }
        [Required]
        public string WorkDescription { get; set; }
        public string Type { get; set; }

        public List<PeopleRequired> PeopleRequired { get; set; }

        public List<Application> Applications { get; set; }
        public List<Tag> Tags { get; set; }

        public int Tokens { get; set; }
        public string Poster { get; set; }
        public string Title { get; set; }

        public string Location { get; set; }

        [Required]
        public Guid IdOrganization { get; set; }
    }
}
