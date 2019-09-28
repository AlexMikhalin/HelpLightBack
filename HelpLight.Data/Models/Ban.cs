using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace HelpLight.Data.Models
{

    public class Ban
    {
        [Key]
        public Guid IdBan { get; set; }
        [Required]
        public string Reason { get; set; }

        [Required]
        public Guid IdVolunteer { get; set; }
        public Volunteer Volunteer { get; set; }

        [Required]
        public Guid IdOrganization { get; set; }
        public Organization Organization { get; set; }
    }
}
