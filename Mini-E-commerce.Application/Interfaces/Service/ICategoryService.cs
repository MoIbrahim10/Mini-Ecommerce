using Mini_E_commerce.Application.Interfaces.Repository;
using Mini_E_commerce.Application.Interfaces.Services.Base;
using Models;

namespace Mini_E_commerce.Application.Interfaces.Services
{
    public interface ICategoryService : IService<Category>, ICategoryRepository
    {

    }
}