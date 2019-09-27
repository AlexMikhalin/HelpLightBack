using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace HelpLight.Data.Models
{
    public class ReviewOfVolunteer
    {
        [Key]
        public Guid IdReviewOfVolunteer { get; set; }
        [Required]
        public string Review { get; set; }
        [Required]
        public int Stars { get; set; }

        public Guid IdVolunteer { get; set; }
        public Volunteer Volunteer { get; set; }

        public Guid IdOrganization { get; set; }
        public Organization Organization { get; set; }
    }
}
