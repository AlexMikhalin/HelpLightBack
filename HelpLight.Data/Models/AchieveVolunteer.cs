using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace HelpLight.Data.Models
{
    public class AchieveVolunteer
    {
        public Guid IdVolunteer { get; set; }
        public Volunteer Volunteer { get; set; }

        public Guid IdAchieve { get; set; }
        public Achieve Achieve { get; set; }
    }
}
