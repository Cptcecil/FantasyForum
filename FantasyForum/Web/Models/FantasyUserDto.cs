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
    public class FantasyUserDto
    {
        public string Name { get; set; }

        public string Bio { get; set; }

        public string PictureUrl { get; set; }

        public string TagLine { get; set; }
    }
}