using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web.Models.DTOs
{
    public class NewsItemDto
    {
        public int Id { get; set; }

        public string CreatedById { get; set; }

        public string Title { get; set; }

        public DateTime LastUpdated { get; set; }

        public string Headline { get; set; }

        public string CreatedBy { get; set; }

        public string Body { get; set; }

        public string HeadlineImgSrc { get; set; }

        public bool CanEdit { get; set; }

        public List<CommentDto> Comments { get; set; }
    }
}