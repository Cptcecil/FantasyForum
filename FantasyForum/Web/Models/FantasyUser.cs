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
    public class FantasyUser : IdentityUser
    {
        public FantasyUser()
        {
            UserWrestlers = new List<UserWrestler>();
        }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<FantasyUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }

        public string Name { get; set; }

        public string Bio { get; set; }

        public string PictureUrl { get; set; }

        public string TagLine { get; set; }

        public virtual ICollection<UserWrestler> UserWrestlers { get; set; }
    }
}