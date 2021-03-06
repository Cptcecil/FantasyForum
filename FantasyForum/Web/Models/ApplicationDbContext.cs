﻿using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Web.Models
{
    public class ApplicationDbContext : IdentityDbContext<FantasyUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public DbSet<Wrestler> Wrestlers { get; set; }

        public DbSet<UserWrestler> UserWrestlers { get; set; }

        public DbSet<NewsItem> NewsItems { get; set; }

        protected override void OnModelCreating(DbModelBuilder mb)
        {
            base.OnModelCreating(mb);

            var userWrestler = mb.Entity<UserWrestler>();

            userWrestler.HasRequired(x => x.Wrestler);

            userWrestler.HasRequired(x => x.User)
                .WithMany(x => x.UserWrestlers);
            
            var newsItem = mb.Entity<NewsItem>();

            newsItem.HasRequired(x => x.CreatedBy)
                .WithMany()
                .HasForeignKey(x=>x.CreatedById);
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}