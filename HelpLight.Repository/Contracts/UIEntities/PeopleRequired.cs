using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using HelpLight.Data.Models;

namespace HelpLight.Repository.Contracts
{
    public class PeopleRequired
    {
        [Required]
        public Guid IdPeopleRequired { get; set; }
        public string Work { get; set; }
        public string Desc { get; set; }
        public string Requirements { get; set; }
        public int Tokens { get; set; }
        public int Amount { get; set; }
        public int Found { get; set; }

        [Required]
        public Guid IdEvent { get; set; }
    }
}
