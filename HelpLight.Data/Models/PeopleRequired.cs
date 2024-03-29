﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace HelpLight.Data.Models
{
    public class PeopleRequired
    {
        [Key]
        public Guid IdPeopleRequired { get; set; }
        public string Work { get; set; }
        public string Desc { get; set; }
        public string Requirements { get; set; }
        public int Tokens { get; set; }
        public int Amount { get; set; }
        public int Found { get; set; }

        [Required]
        public Guid IdEvent { get; set; }
        public Event Event { get; set; }
    }
}
