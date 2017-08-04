using System.Data.Entity;
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
        
        public DbSet<NewsItem> NewsItems { get; set; }

        public DbSet<Comment> Comments { get; set; }

        protected override void OnModelCreating(DbModelBuilder mb)
        {
            base.OnModelCreating(mb);
            
            var newsItem = mb.Entity<NewsItem>();

            newsItem.HasRequired(x => x.CreatedBy)
                .WithMany()
                .HasForeignKey(x=>x.CreatedById)
                .WillCascadeOnDelete(false);

            newsItem.HasMany(x => x.Comments)
                .WithRequired()
                .HasForeignKey(x=>x.NewsItemId)
                .WillCascadeOnDelete(true);

            var comments = mb.Entity<Comment>();

            comments.HasRequired(x => x.CreatedBy)
                .WithMany()
                .HasForeignKey(x => x.CreatedById)
                .WillCascadeOnDelete(false);
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}