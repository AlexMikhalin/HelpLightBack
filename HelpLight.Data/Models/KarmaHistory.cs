using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace HelpLight.Data.Models
{
    public class KarmaHistory
    {
        [Key]
        public Guid IdKarmaHistory { get; set; }
        public DateTime DateModified { get; set; }
        [Required]
        public int Gained { get; set; }
        public string Reason { get; set; }

        [Required]
        public Guid IdKarma { get; set; }
        public Karma Karma { get; set; }

        public Guid IdEvent { get; set; }
        public Event Event { get; set; }
    }
}
