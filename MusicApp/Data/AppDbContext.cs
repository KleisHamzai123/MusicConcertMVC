using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MusicApp.Models;

namespace MusicApp.Data
{
    public class AppDbContext: IdentityDbContext<ApplicationUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Song_Concert>().HasKey(am => new
            {
                am.SongId,
                am.ConcertId
            });

            modelBuilder.Entity<Song_Concert>().HasOne(m => m.Concert).WithMany(am => am.Songs_Concerts).HasForeignKey(m => m.ConcertId);
            modelBuilder.Entity<Song_Concert>().HasOne(m => m.Song).WithMany(am => am.Songs_Concerts).HasForeignKey(m => m.SongId);


            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Song> Songs { get; set; }
        public DbSet<Concert> Concerts { get; set; }
        public DbSet<Song_Concert> Songs_Concerts { get; set; }
        public DbSet<Place> Places { get; set; }
        public DbSet<Organisator> Organisators { get; set; }


        //Orders related tables
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<ShoppingCartItem> ShoppingCartItems { get; set; }
    }


}

