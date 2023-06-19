using Dtos;

namespace MiniEcommerce.UI.Services
{
    public interface IService<T, TCreate>
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetByIdAsync(int id);
        Task<T> AddAsync(TCreate entity);
        Task UpdateAsync(int id, TCreate entity);
        Task DeleteAsync(int id);
    }

}
