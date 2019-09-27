using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace HelpLight.Data.Models
{
    public class Achieve
    {
        [Key]
        public Guid IdAchieve { get; set; }

        public string Description { get; set; }

        public List<AchieveVolunteer> AchieveVolunteers { get; set; }
    }
}
