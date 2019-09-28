using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace HelpLight.Data.Models
{
    public class Contact
    {
        [Key]
        public Guid IdContact { get; set; }

        public Guid IdVolunteer { get; set; }

        public string Telegram { get; set; }
        public string Vk { get; set; }
        public string Wp { get; set; }
        public string Fb { get; set; }
        public string Inst { get; set; }
    }
}
