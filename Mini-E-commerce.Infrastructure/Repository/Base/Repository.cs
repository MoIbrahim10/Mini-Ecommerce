using Microsoft.EntityFrameworkCore;
using Mini_E_commerce.Application.Interfaces.Repository.Base;
using Models;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace Mini_E_commerce.Infrastructure.Repository.Base
{
    public class Repository<TClass> : IRepository<TClass> where TClass : class, IEntity
    {
        private readonly MiniEcommerceDbContext _context;
        private readonly DbSet<TClass> _dbSet;

        public Repository(MiniEcommerceDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<TClass>();
        }


        public async Task<IEnumerable<TClass>> GetAllAsync(params Expression<Func<TClass, object>>[] IncludeProperties)
        {
            IQueryable<TClass> Query = _dbSet;
            Query = IncludeProperties.Aggregate(Query, (current, includeProperty) => current.Include(includeProperty));
            return await Query.ToListAsync();
        }

        public async Task<TClass> GetByIdAsync(int id, params Expression<Func<TClass, object>>[] IncludeProperties)
        {

            IQueryable<TClass> Query = _dbSet;
            Query = IncludeProperties.Aggregate(Query, (current, includeProperty) => current.Include(includeProperty));
            var entity = await Query.FirstOrDefaultAsync(q => q.Id.Equals(id));

            return entity ?? throw new KeyNotFoundException($"No entity with id {id} found.");
        }


        public async Task<TClass> AddAsync(TClass entity)
        {
            _dbSet.Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<TClass> UpdateAsync(TClass entity)
        {
            _dbSet.Update(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task DeleteAsync(int id)
        {
            _dbSet.Remove(await GetByIdAsync(id));
            await _context.SaveChangesAsync();
        }


    }
}
