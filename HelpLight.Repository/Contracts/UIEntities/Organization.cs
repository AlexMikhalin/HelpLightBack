using System;
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
        public string Name { get; set; }
        public string Avatar { get; set; }
        public string Email { get; set; }
        public string Desc { get; set; }
        public string Title { get; set; }
        public string City { get; set; }
        public string Tags { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public int Balance { get; set; }
    }
}
