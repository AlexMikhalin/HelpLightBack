using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace HelpLight.Repository.Contracts
{
    public class AchieveVolunteer
    {
        [Required]
        public Guid IdVolunteer { get; set; }
        public Achieve Achieve { get; set; }
    }
}
