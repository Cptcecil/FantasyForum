using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Web.Models
{
    public class UserMatch
    {
        public FantasyUserDto User { get; set; }
        public Wrestler Wrestler { get; set; }
        public int Order { get; set; }
    }
}