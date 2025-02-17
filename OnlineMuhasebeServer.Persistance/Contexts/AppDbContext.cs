using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using OnlineMuhasebeServer.Domain.Abstractions;
using OnlineMuhasebeServer.Domain.AppEntities;
using OnlineMuhasebeServer.Domain.AppEntities.Identity;

namespace OnlineMuhasebeServer.Persistance.Contexts;

public sealed class AppDbContext : IdentityDbContext<AppUser, AppRole, string>
{
    public AppDbContext(DbContextOptions options) : base(options)
    {
    }
    public DbSet<Company> Companies { get; set; }
    public DbSet<UserAndCompanyRelationship> UserAndCompanyRelationships { get; set; }

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
    {
        var entries = ChangeTracker.Entries<Entity>();
        foreach (var entry in entries)
        {
            if (entry.State == EntityState.Added)
            {
                entry.Property(p => p.CreatedDate).CurrentValue = DateTime.UtcNow;
            }

            if (entry.State == EntityState.Modified)
            {
                entry.Property(p => p.UpdateDate).CurrentValue = DateTime.UtcNow;
            }
        }
        return base.SaveChangesAsync(cancellationToken);
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.Ignore<IdentityUserLogin<string>>();
        builder.Ignore<IdentityUserRole<string>>();
        builder.Ignore<IdentityUserClaim<string>>();
        builder.Ignore<IdentityUserToken<string>>();
        builder.Ignore<IdentityRoleClaim<string>>();
    }

    public class AppDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
    {
        public AppDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder= new DbContextOptionsBuilder();
            var connectionString ="Server=localhost;Database=OnlineMuhasebeMaster;User Id=gonulates;Password=123456;Trusted_Connection=True;Encrypt=false;Integrated Security=false;Max Pool Size = 512;";

            optionsBuilder.UseSqlServer(connectionString);

            return new AppDbContext(optionsBuilder.Options);
        }
    }
}