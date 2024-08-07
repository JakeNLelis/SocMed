using backend.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace backend.Data;

public class ApplicationDbContext : IdentityDbContext<AppUser>
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) {}

    public DbSet<Post> Posts { get; set; }
    public DbSet<Comment> Comments { get; set; }
    public DbSet<Relationship> Relationships { get; set; }
    public DbSet<LikedPost> LikedPosts { get; set; }
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.Entity<Relationship>(b => 
        {
            b.HasKey(t => new {t.FollowedUserId, t.FollowingUserId});

            b.HasOne(pt => pt.FollowedUser)
                .WithMany(p => p.Followings)
                .HasForeignKey(pt => pt.FollowedUserId)
                .OnDelete(DeleteBehavior.Restrict);

            b.HasOne(pt => pt.FollowingUser)
                .WithMany(p => p.Followers)
                .HasForeignKey(pt => pt.FollowingUserId)
                .OnDelete(DeleteBehavior.Restrict);
        });

        builder.Entity<Post>(b =>
        {
            b.HasKey(p => p.Id);

            b.HasOne(p => p.AppUser)
                .WithMany(u => u.Posts)
                .HasForeignKey(p => p.AppUserId)
                .OnDelete(DeleteBehavior.Restrict); // or .OnDelete(DeleteBehavior.Cascade) based on your needs

            b.HasMany(p => p.Comments)
                .WithOne(c => c.Post)
                .HasForeignKey(c => c.PostId)
                .OnDelete(DeleteBehavior.Cascade); // Ensure Comments are deleted when a Post is deleted
        });

        builder.Entity<Comment>(b =>
        {
            b.HasKey(c => c.Id);

            b.HasOne(c => c.Post)
                .WithMany(p => p.Comments)
                .HasForeignKey(c => c.PostId)
                .OnDelete(DeleteBehavior.Cascade); // Ensure Comments are deleted when a Post is deleted

            b.HasOne(c => c.AppUser)
                .WithMany(u => u.Comments)
                .HasForeignKey(c => c.AppUserId)
                .OnDelete(DeleteBehavior.Restrict); // or .OnDelete(DeleteBehavior.Cascade) based on your needs
        });

        builder.Entity<LikedPost>(p => 
        {
            p.HasKey(p => new { p.LikeUserId, p.PostId});

            p.HasOne(u => u.LikeUser)
                .WithMany(u => u.Likes)
                .HasForeignKey(u => u.LikeUserId);

            p.HasOne(u => u.Post)
                .WithMany(u => u.Likes)
                .HasForeignKey(u => u.PostId);

        });

        List<IdentityRole> roles= new List<IdentityRole>
        {
            new IdentityRole 
            {
                Name = "Admin",
                NormalizedName = "ADMIN"
            },
            new IdentityRole
            {
                Name = "User",
                NormalizedName = "USER"
            }
        };

        builder.Entity<IdentityRole>().HasData(roles);
    }
    
}