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
        public DbSet<PostTag> post_tag { get; set; }
        public DbSet<Profile> Profile { get; set; }
        public DbSet<FriendshipNotification> friend_notify { get; set; }
        //public DbSet<LikesNotification> likes_notify { get; set; }
        public DbSet<CommentsNotifications> comments_notify { get; set; }
        //public DbSet<UserLikesNotify> UserLikesNotify { get; set; }
        public DbSet<UserCommentsNotify> UserCommentsNotify { get; set; }
        public DbSet<UserFriendNotify> UserFriendNotify { get; set; }

        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            /*
             modelBuilder.Entity<Note>()
                .HasOptional(a => a.NoteTaker)
                .WithOptionalDependent()
                .WillCascadeOnDelete(true);
             */
             
            modelBuilder.Entity<UserFriendNotify>(
                )
                .HasRequired(x => x.User)
                .WithMany()
                .WillCascadeOnDelete(false);
            
            base.OnModelCreating(modelBuilder);
}
    
       
    }
}
 