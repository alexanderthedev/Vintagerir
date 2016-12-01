using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;

namespace Vintagerie.Models
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductCategory> ProductCategories { get; set; }
        public DbSet<PictureInfo> PIctureInfos { get; set; }

        public DbSet<LikeUserToProduct> Likes { get; set; }
        public DbSet<LovesUserToStore> Loves { get; set; }

        public DbSet<MessageRoom> MessageRooms { get; set; }
        public DbSet<Message> Messages { get; set; }
        
        public DbSet<Notification> Notifications { get; set; }
        public DbSet<UserNotification> UserNotifications { get; set; }  


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
            modelBuilder.Entity<LikeUserToProduct>()
                .HasRequired(u => u.Liker)
                .WithMany()
                .WillCascadeOnDelete(false);


            modelBuilder.Entity<LovesUserToStore>()
                .HasRequired(u => u.LoverUser)
                .WithMany()
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Message>()
                .HasRequired(m => m.Receiver)
                .WithMany()
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<UserNotification>()
                .HasRequired(m => m.User)
                .WithMany()
                .WillCascadeOnDelete(false);



            base.OnModelCreating(modelBuilder);
        }
    }
}