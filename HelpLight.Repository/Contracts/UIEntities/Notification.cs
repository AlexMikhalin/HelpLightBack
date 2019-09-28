using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace HelpLight.Repository.Contracts
{
    public class Notification
    {
        [Required]
        public Guid IdNotification { get; set; }

        public Guid IdUser { get; set; }

        public string Description { get; set; }
    }
}
