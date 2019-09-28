using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace HelpLight.Repository.Contracts
{
    public class Comment
    {
        [Required]
        public Guid IdComment { get; set; }
        [Required]
        public string CommentText { get; set; }

        [Required]
        public Guid IdVolunteer { get; set; } // not unique
        public Volunteer Volunteer { get; set; }

        [Required]
        public Guid IdWallRecord { get; set; } // not unique
    }
}
