using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web.Models
{
    public class UserWrestler
    {
        public int Id { get; set; }

        public string UserId { get; set; }
        
        public int WrestlerId { get; set; }

        public int Order { get; set; }

        public virtual FantasyUser User { get; set; }

        public virtual Wrestler Wrestler { get; set; }
    }
}