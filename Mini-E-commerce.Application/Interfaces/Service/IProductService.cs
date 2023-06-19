using Mini_E_commerce.Application.Interfaces.Repository;
using Mini_E_commerce.Application.Interfaces.Services.Base;
using Models;

namespace Mini_E_commerce.Application.Interfaces.Services
{
    public interface IProductService : IService<Product>, IProductRepository
    {

    }
}