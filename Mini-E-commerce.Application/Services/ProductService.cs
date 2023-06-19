using Mini_E_commerce.Application.Interfaces.Repository;
using Mini_E_commerce.Application.Interfaces.Services;
using Mini_E_commerce.Application.Services.Base;
using Models;


namespace Mini_E_commerce.Application.Services
{

    public class ProductService : Service<Product>, IProductService
    {

        public ProductService(IProductRepository context) : base(context)
        {
        }

    }
}
