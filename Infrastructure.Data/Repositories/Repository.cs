using Domain.Interfaces;
using Infrastructure.Data.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Infrastructure.Data.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private readonly DesafioSofiaContext _context;
        public Repository(DesafioSofiaContext context)
        {
            _context = context;
        }
        public async Task CreateAsync(TEntity entity)
        {
            await _context.Set<TEntity>().AddAsync(entity);

            await _context.SaveChangesAsync();
        }
        public async Task AddRanger(IEnumerable<TEntity> entities)
        {
            await _context.Set<TEntity>().AddRangeAsync(entities);

            await _context.SaveChangesAsync();
        }
        public void Update(TEntity entity)
        {
            _context.Set<TEntity>().Update(entity);

            _context.SaveChanges();
        }
        public async Task<IEnumerable<TEntity>> GetAsync()
          => await _context.Set<TEntity>().ToListAsync();
        public async Task<TEntity> GetByIdAsync(int id)
           => await _context.Set<TEntity>().FindAsync(id);
        public async Task<IEnumerable<TEntity>> SearchAsync(Expression<Func<TEntity, bool>> expression)
          => await _context.Set<TEntity>().Where(expression).ToListAsync();
        public bool FindAny(Expression<Func<TEntity, bool>> expression)
           => _context.Set<TEntity>().Any(expression);
        public async Task<int> RemoveAsync(int id)
        {
            var entity = await GetByIdAsync(id);

            _context.Set<TEntity>().Remove(entity);

            _context.SaveChanges();

            return await Task.FromResult(default(int));
        }
        public void RemoveAsync(IEnumerable<TEntity> entities)
        {
            _context.Set<TEntity>().RemoveRange(entities);

            _context.SaveChanges();
        }
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
