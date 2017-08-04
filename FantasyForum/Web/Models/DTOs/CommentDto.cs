using System;

namespace Web.Models.DTOs
{
    public class CommentDto
    {
        public int Id { get; set; }

        public DateTime LastUpdated { get; set; }

        public string Content { get; set; }

        public virtual FantasyUser CreatedBy { get; set; }

        public bool CanEdit { get; set; }

        public int NewsItemId { get; set; }
    }
}