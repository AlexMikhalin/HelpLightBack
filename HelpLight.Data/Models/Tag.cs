using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace HelpLight.Data.Models
{
    public class Tag
    {
        [Key]
        public Guid IdTag { get; set; }
        public string Description { get; set; }

        public Guid IdEvent { get; set; }
        public Event Event { get; set; }
    }
}
