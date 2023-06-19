using Models;
using System.Linq.Expressions;

namespace Mini_E_commerce.Application.Interfaces.Repository.Base
{
    public interface IRepository<TClass> where TClass : class, IEntity
    {


        Task<IEnumerable<TClass>> GetAllAsync(params Expression<Func<TClass, object>>[] IncludeProperties);
        Task<TClass> GetByIdAsync(int id, params Expression<Func<TClass, object>>[] IncludeProperties);

        Task<TClass> AddAsync(TClass entity);

        Task<TClass> UpdateAsync(TClass entity);
        Task DeleteAsync(int id);



    }
}