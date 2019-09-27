using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace HelpLight.Repository.Contracts
{
    public class WallRecord
    {
        public WallRecord()
        {
            Comments = new List<Comment>();
        }

        [Required]
        public Guid IdWallRecord { get; set; }
        [Required]
        public string TextContent { get; set; }

        [Required]
        public Guid IdOrganization { get; set; } // not unique

        public List<Comment> Comments { get; set; }
    }
}
