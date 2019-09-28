using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace HelpLight.Repository.Contracts
{
    public class Skill
    {
        public Guid IdSkill { get; set; }
        [Required]
        public string Description { get; set; }

        public Guid IdVolunteer { get; set; }
    }
}
