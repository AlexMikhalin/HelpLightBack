using System;
using System.Collections.Generic;
using System.Text;

namespace HelpLight.Data.Models
{
    public class Article
    {
        public int Likes { get; set; }

        public string IdWallRecord { get; set; }

        public string Poster { get; set; }

        public string TextContent { get; set; }

        public string IdOrganization { get; set; }
    }
}
