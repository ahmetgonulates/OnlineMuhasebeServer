using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using OnlineMuhasebeServer.Domain.Abstractions;
using OnlineMuhasebeServer.Domain.AppEntities;

namespace OnlineMuhasebeServer.Persistance.Contexts;

public sealed class CompanyDbContext : DbContext
{
    private string ConnectionString = "";
    
    public CompanyDbContext(Company company = null)
    {
        if (company != null)
        {
            if (company.ServerUserId == "")
                ConnectionString = 
                    $"Server={company.ServerName};" +
                    $"Database={company.DatabaseName};" +
                    $"Trusted_Connection=True;" +
                    $"Encrypt=false;" +
                    $"Integrated Security=false;" +
                    $"Max Pool Size = 512;";
            else
                ConnectionString =
                    $"Server={company.ServerName};" +
                    $"Database={company.DatabaseName};" +
                    $"User Id={company.ServerUserId};" +
                    $"Password={company.ServerPassword};" +
                    $"Trusted_Connection=True;" +
                    $"Encrypt=false;" +
                    $"Integrated Security=false;" +
                    $"Max Pool Size = 512;";    
        }
        
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(ConnectionString);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
        => modelBuilder.ApplyConfigurationsFromAssembly(typeof(AssemblyReference).Assembly);

    public class CompanyDbContextFactory : IDesignTimeDbContextFactory<CompanyDbContext>
    {
        public CompanyDbContext CreateDbContext(string[] args)
        {
            return new CompanyDbContext();
        }
    }

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
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
}