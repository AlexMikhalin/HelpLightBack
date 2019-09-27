using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace HelpLight.Data.Models
{
    public class LastWorkDate
    {
        [Key]
        public Guid IdLastWorkDate { get; set; }
        public DateTime Date { get; set; }

        [Required]
        public Guid IdVolunteer { get; set; } // unique
        public Volunteer Volunteer { get; set; }
    }
}
