﻿using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace HelpLight.Repository.Contracts
{
    public class Organization
    {
        [Required]
        public Guid IdOrganization { get; set; }
        [Required]
        public string OrganizationName { get; set; }
        [Required]
        public string Address { get; set; }
    }
}
