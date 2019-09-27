using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace HelpLight.Repository.Contracts
{
    public class ReviewOfVolunteer
    {
        [Required]
        public Guid IdReviewOfVolunteer { get; set; }
        [Required]
        public Guid IdVolunteer { get; set; }
        [Required]
        public Guid IdOrganization { get; set; }
        [Required]
        public string Review { get; set; }
        [Required]
        public int Stars { get; set; }
    }
}
