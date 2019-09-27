using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace HelpLight.Repository.Contracts
{
    public class Ban
    {
        [Required]
        public Guid IdBan { get; set; }
        [Required]
        public string Reason { get; set; }
        [Required]
        public DateTime DateFrom { get; set; }
        [Required]
        public DateTime DateTo { get; set; }

        [Required]
        public Guid IdVolunteer { get; set; }
    }
}
