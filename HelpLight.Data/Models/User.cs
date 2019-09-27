using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace HelpLight.Data.Models
{
    public class User
    {
        [Key]
        public Guid IdUser { get; set; }
        [Required]
        public string UserName { get; set; }
        [Required]
        public string PasswordHash { get; set; }

        public Volunteer Volunteer { get; set; }
        public Organization Organization { get; set; }
    }
}
