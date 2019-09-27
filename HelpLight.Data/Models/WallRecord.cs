using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace HelpLight.Data.Models
{
    public class WallRecord
    {
        public WallRecord()
        {
            Comments = new List<Comment>();
        }

        [Key]
        public Guid IdWallRecord { get; set; }
        [Required]
        public string TextContent { get; set; }

        [Required]
        public Guid IdOrganization { get; set; } // not unique
        public Organization Organization { get; set; }

        public List<Comment> Comments { get; set; }
    }
}
