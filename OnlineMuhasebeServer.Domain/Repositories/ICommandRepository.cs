using Microsoft.EntityFrameworkCore;
using OnlineMuhasebeServer.Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineMuhasebeServer.Domain.Repositories
{
    public interface ICommandRepository<T> : IRepository<T> 
        where T : Entity
    {
        Task AddAsync(T entity, CancellationToken cancellationToken);
        Task AddRangeAsync(IEnumerable<T> entities, CancellationToken cancellationToken);
        void UpdateAsync(T entity);
        void UpdateRangeAsync(IEnumerable<T> entities);
        Task RemoveByIdAsync(string id);
        void Remove(T entity);
        void RemoveRange(IEnumerable<T> entities);
    }
}
