using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IRepository<TEntity> : IDisposable where TEntity : class
    {
        Task<IEnumerable<TEntity>> GetAsync();

        Task<TEntity> GetByIdAsync(int id);

        Task<IEnumerable<TEntity>> SearchAsync(Expression<Func<TEntity, bool>> expression);

        bool FindAny(Expression<Func<TEntity, bool>> expression);

        Task CreateAsync(TEntity entity);

        Task AddRanger(IEnumerable<TEntity> entities);

        void Update(TEntity entity);

        Task<int> RemoveAsync(int id);

        void RemoveAsync(IEnumerable<TEntity> entities);
    }
}