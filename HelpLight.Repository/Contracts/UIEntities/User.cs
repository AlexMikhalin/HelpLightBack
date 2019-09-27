using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace HelpLight.Repository.Contracts
{
    public class User
    {
        [Required]
        public Guid IdUser { get; set; }
        [Required]
        public string UserName { get; set; }
        [Required]
        public string PasswordHash { get; set; }
        [Required]
        public string Role { get; set; }
        public Volunteer Volunteer { get; set; }
        public Organization Organization { get; set; }
    }
}
