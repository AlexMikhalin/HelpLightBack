using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace HelpLight.Data.Models
{
    public class Card
    {
        [Key]
        public Guid IdCard { get; set; }

        [Required]
        public DateTime From { get; set; }
        [Required]
        public DateTime To { get; set; }

        [Required]
        public Guid IdVolunteer { get; set; } // unique
        public Volunteer Volunteer { get; set; }
    }
}
