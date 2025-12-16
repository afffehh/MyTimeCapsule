using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MyTimeCapsule.Server.Models;

namespace MyTimeCapsule.Server.Data;

public class ApplicationDbContext : IdentityDbContext<ApplicationUser, IdentityRole, string>
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options) { }

    public DbSet<Album> Albums => Set<Album>();
    public DbSet<Photo> Photos => Set<Photo>();
    public DbSet<Category> Categories => Set<Category>();

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=MyTimeCapsuleDb;Trusted_Connection=True");
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.Entity<Album>()
                .HasOne(a => a.User)
                .WithMany(u => u.Albums)
                .HasForeignKey(a => a.UserId)
                .OnDelete(DeleteBehavior.Cascade);


        builder.Entity<Photo>()
                .HasOne(p => p.Album)
                .WithMany(a => a.Photos)
                .HasForeignKey(p => p.AlbumId)
                .OnDelete(DeleteBehavior.Cascade);


        builder.Entity<Photo>()
                .HasOne(p => p.Category)
                .WithMany(c => c.Photos)
                .HasForeignKey(p => p.CategoryId)
                .OnDelete(DeleteBehavior.SetNull);


        builder.Entity<Category>().HasData(
            new Category { Id = 1, Name = "Uncategorized" },
            new Category { Id = 2, Name = "Travel" },
            new Category { Id = 3, Name = "Family" },
            new Category { Id = 4, Name = "Friends" },
            new Category { Id = 5, Name = "Holidays" },
            new Category { Id = 6, Name = "Hobbies" },
            new Category { Id = 7, Name = "Nature" },
            new Category { Id = 8, Name = "Pets" }
        );
    }


}