using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace HelpLight.Repository.Contracts
{
    public class Volunteer
    {
        [Required]
        public Guid IdVolunteer { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        public bool Banned { get; set; }
        public DateTime Birthday { get; set; }
        public Karma Karma { get; set; }
        public Contact Contacts { get; set; }
        public string CuretedBy { get; set; }
    }
}
