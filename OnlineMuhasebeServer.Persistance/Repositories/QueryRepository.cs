using Microsoft.EntityFrameworkCore;
using OnlineMuhasebeServer.Domain.Abstractions;
using OnlineMuhasebeServer.Domain.Repositories;
using OnlineMuhasebeServer.Persistance.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace OnlineMuhasebeServer.Persistance.Repositories;

public class QueryRepository<T> : IQueryRepository<T> where T : Entity
{
    private static readonly Func<CompanyDbContext, string, bool, Task<T>> GetByIdCompiled = EF.CompileAsyncQuery((CompanyDbContext context, string id, bool isTracking) => isTracking ? context.Set<T>().FirstOrDefault(x => x.Id == id) : context.Set<T>().AsNoTracking().FirstOrDefault(x => x.Id == id));
    private static readonly Func<CompanyDbContext, bool, Task<T>> GetFirstCompiled = EF.CompileAsyncQuery((CompanyDbContext context, bool isTracking) => isTracking ? context.Set<T>().FirstOrDefault() : context.Set<T>().AsNoTracking().FirstOrDefault());
    private static readonly Func<CompanyDbContext, bool, Expression<Func<T, bool>>, Task<T>> GetFirstByExpressionCompiled = EF.CompileAsyncQuery((CompanyDbContext context, bool isTracking, Expression<Func<T, bool>> expression) => isTracking ? context.Set<T>().FirstOrDefault(expression) : context.Set<T>().AsNoTracking().FirstOrDefault(expression));



    private CompanyDbContext _context;
    public DbSet<T> DbSet { get; set; }

    public void SetDbContextInstance(DbContext context)
    {
        _context = (CompanyDbContext)context;
        DbSet = _context.Set<T>();
    }

    public IQueryable<T> GetAllAsync(bool isTracking = true)
    {
        var result = DbSet.AsQueryable();
        if (!isTracking)
            result = result.AsNoTracking();
        return result;
    }


    public async Task<T> GetByIdAsync(string id, bool isTracking = true)
        => await GetByIdCompiled(_context, id, isTracking);

    public async Task<T> GetFirstAsync(bool isTracking = true)
        => await GetFirstCompiled(_context, isTracking);

    public async Task<T> GetFirstByExpressionAsync(Expression<Func<T, bool>> expression, bool isTracking = true)
         => await GetFirstByExpressionCompiled(_context, isTracking, expression);

    public IQueryable<T> GetWhereAsync(Expression<Func<T, bool>> expression, bool isTracking = true)
        => isTracking ? DbSet.Where(expression) : DbSet.Where(expression).AsNoTracking();
}
