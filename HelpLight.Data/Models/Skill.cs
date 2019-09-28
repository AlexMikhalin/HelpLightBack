using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace HelpLight.Data.Models
{
    public class Skill
    {
        [Key]
        public Guid IdSkill { get; set; }
        public string Description { get; set; }

        public Guid IdVolunteer { get; set; }
        public Volunteer Volunteer { get; set; }
    }
}
