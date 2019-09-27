using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace HelpLight.Repository.Contracts
{
    public class KarmaHistory
    {
        private DateTime dateModified;

        [Key]
        public Guid IdKarmaHistory { get; set; }
        public DateTime DateModified { get { return dateModified; } set { dateModified = DateTime.Now; } }
        [Required]
        public int Gained { get; set; }
        public string Reason { get; set; }

        [Required]
        public Guid IdKarma { get; set; }

        public Guid IdEvent { get; set; }
    }
}
