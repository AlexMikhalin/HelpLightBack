﻿using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace HelpLight.Repository.Contracts
{
    public class Volunteer
    {
        [Required]
        public Guid IdVolunteer { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
    }
}
