using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace HelpLight.Repository.Contracts
{
    public class Achieve
    {
        [Required]
        public Guid IdAchieve { get; set; }
        [Required]
        public string Description { get; set; }
    }
}
