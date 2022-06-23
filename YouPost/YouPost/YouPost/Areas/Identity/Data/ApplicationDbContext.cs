using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using YouPost.Areas.Identity.Data;
using YouPost.Models;

namespace YouPost.Data;

public class ApplicationDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, Guid>
{
    public DbSet<ApplicationUser> Users { get; set; }
    public DbSet<ApplicationRole> Roles { get; set; }
    public DbSet<Post>Posts { get; set; }
    public DbSet<Subscription> Subscriptions { get; set; }
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<ApplicationRole>()
            .HasData(new ApplicationRole {Id=Guid.NewGuid(), Name = "user", NormalizedName = "user" });
       
    }
   

}

