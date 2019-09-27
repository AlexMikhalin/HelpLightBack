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
        [Required]
        public int PeopleRequired { get; set; }
        [Required]
        public int Tokens { get; set; }

        [Required]
        public Guid IdOrganization { get; set; }
    }
}
