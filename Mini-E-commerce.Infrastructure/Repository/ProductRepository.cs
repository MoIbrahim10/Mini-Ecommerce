using Mini_E_commerce.Application.Interfaces.Repository;
using Mini_E_commerce.Infrastructure.Repository.Base;
using Models;


namespace Mini_E_commerce.Infrastructure.Repository
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        public ProductRepository(MiniEcommerceDbContext context) : base(context)
        {

        }

    }
}
