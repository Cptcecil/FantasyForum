using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web.Models
{
    public class NewsItem
    {
        public NewsItem()
        {
            Comments = new List<Comment>();
        }

        public int Id { get; set; }

        public string CreatedById { get; set; }

        public string Title { get; set; }

        public DateTime LastUpdated { get; set; }

        public string Body { get; set; }

        public string Headline { get; set; }

        public virtual FantasyUser CreatedBy { get; set; }

        public virtual List<Comment> Comments { get; set; }
    }
}