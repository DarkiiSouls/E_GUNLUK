using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace E_GUNLUK.Models
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Note> notes { get; set; }
        public DbSet<Tags> tags { get; set; }
        public DbSet<Comments> comments { get; set; }
        public DbSet<Likes> likes { get; set; }
        public DbSet<FriendsList> friendsList { get; set; }
        public DbSet<Favorites> favorites { get; set; }
       // public DbSet<TagsNotesRel> tagsNotesRel { get; set; }
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

/*
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Note>()
                .HasOptional(a => a.NoteTaker)
                .WithOptionalDependent()
                .WillCascadeOnDelete(true);
        }
*/
    }
}
 