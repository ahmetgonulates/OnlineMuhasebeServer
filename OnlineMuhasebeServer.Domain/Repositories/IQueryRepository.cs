using OnlineMuhasebeServer.Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace OnlineMuhasebeServer.Domain.Repositories
{
    public interface IQueryRepository<T> : IRepository<T> 
        where T : Entity
    {
        IQueryable<T> GetAllAsync(bool isTracking = true);
        IQueryable<T> GetWhereAsync(Expression<Func<T, bool>> expression, bool isTracking = true);
        Task<T> GetByIdAsync(string id, bool isTracking = true);
        Task<T> GetFirstByExpressionAsync(Expression<Func<T, bool>> expression, bool isTracking = true);    
        Task<T> GetFirstAsync(bool isTracking = true);
    }
}
