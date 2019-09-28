using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace HelpLight.Repository.Contracts
{
    public class Tag
    {
        [Required]
        public Guid IdTag { get; set; }
        public string Description { get; set; }

        public Guid IdEvent { get; set; }
    }
}
