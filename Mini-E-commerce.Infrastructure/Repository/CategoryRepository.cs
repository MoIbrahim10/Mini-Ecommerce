using Mini_E_commerce.Application.Interfaces.Repository;
using Mini_E_commerce.Infrastructure.Repository.Base;
using Models;

namespace Mini_E_commerce.Infrastructure.Repository
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        public CategoryRepository(MiniEcommerceDbContext context) : base(context)
        {

        }
    }
}
