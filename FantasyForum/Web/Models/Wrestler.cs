using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web.Models
{
    public class Wrestler
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string PictureUrl { get; set; }

        public int DefenseHead { get; set; }

        public int DefenseBody { get; set; }

        public int DefenseArms { get; set; }

        public int DefenseLegs { get; set; }

        public int DefenseFlying { get; set; }

        public int OffenseHead { get; set; }

        public int OffenseBody { get; set; }

        public int OffenseArms { get; set; }

        public int OffenseLegs { get; set; }

        public int OffenseFlying { get; set; }
    }
}