using System;

namespace Web.Models
{
    public class Comment
    {
        public int Id { get; set; }

        public int NewsItemId { get; set; }

        public DateTime LastUpdated { get; set; }

        public string Content { get; set; }

        public string CreatedById { get; set; }

        public virtual FantasyUser CreatedBy { get; set; }
    }
}