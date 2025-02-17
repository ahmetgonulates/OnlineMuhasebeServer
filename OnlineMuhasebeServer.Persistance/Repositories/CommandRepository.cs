using Microsoft.EntityFrameworkCore;
using OnlineMuhasebeServer.Domain.Abstractions;
using OnlineMuhasebeServer.Domain.Repositories;
using OnlineMuhasebeServer.Persistance.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineMuhasebeServer.Persistance.Repositories;

public class CommandRepository<T> : ICommandRepository<T> where T : Entity
{
    private static readonly Func<CompanyDbContext, string, Task<T>> GetByIdCompiled = EF.CompileAsyncQuery((CompanyDbContext context, string id) => context.Set<T>().FirstOrDefault(x => x.Id == id));

    private CompanyDbContext _context;
    public DbSet<T> DbSet { get; set; }


    public void SetDbContextInstance(DbContext context)
    {
        _context = (CompanyDbContext)context;
        DbSet = _context.Set<T>();
    }

    public async Task AddAsync(T entity)
    {
        await DbSet.AddAsync(entity);
    }

    public async Task AddRangeAsync(IEnumerable<T> entities)
    {
        await DbSet.AddRangeAsync(entities);
    }

    public void Remove(T entity)
    {
        DbSet.Remove(entity);
    }

    public async Task RemoveByIdAsync(string id)
    {
        T entity = await GetByIdCompiled(_context, id);
        Remove(entity);
    }

    public void RemoveRange(IEnumerable<T> entities)
    {
        DbSet.RemoveRange(entities);
    }

    public void UpdateAsync(T entity)
    {
        DbSet.Update(entity);
    }

    public void UpdateRangeAsync(IEnumerable<T> entities)
    {
        DbSet.UpdateRange(entities);
    }
}

