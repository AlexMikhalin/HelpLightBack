using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace HelpLight.Data.Models
{
    public class Notification
    {
        [Key]
        public Guid IdNotification { get; set; }

        public Guid IdUser { get; set; }

        public string Description { get; set; }
    }
}
