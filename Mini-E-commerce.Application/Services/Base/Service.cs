using Mini_E_commerce.Application.Interfaces.Repository.Base;
using Mini_E_commerce.Application.Interfaces.Services.Base;
using Models;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace Mini_E_commerce.Application.Services.Base
{
    public class Service<TEntity> : IService<TEntity> where TEntity : class, IEntity
    {
        protected readonly IRepository<TEntity> _baseContext;


        public Service(IRepository<TEntity> context)
        {
            _baseContext = context;
        }

        public Task<IEnumerable<TEntity>> GetAllAsync(params Expression<Func<TEntity, object>>[] IncludeProperties)
        {
            return _baseContext.GetAllAsync(IncludeProperties);
        }
        public Task<TEntity> GetByIdAsync(int id, params Expression<Func<TEntity, object>>[] IncludeProperties)
        {
            return _baseContext.GetByIdAsync(id, IncludeProperties);
        }
        public Task<TEntity> AddAsync(TEntity entity)
        {
            return _baseContext.AddAsync(entity);
        }

        public Task<TEntity> UpdateAsync(TEntity entity)
        {
            return _baseContext.UpdateAsync(entity);
        }


        public virtual Task DeleteAsync(int id)
        {
            return _baseContext.DeleteAsync(id);
        }

    }

}
