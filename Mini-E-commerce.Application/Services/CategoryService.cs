using Mini_E_commerce.Application.Interfaces.Repository;
using Mini_E_commerce.Application.Interfaces.Services;
using Mini_E_commerce.Application.Services.Base;
using Models;


namespace Mini_E_commerce.Application.Services
{
    public class CategoryService : Service<Category>, ICategoryService
    {

        public CategoryService(ICategoryRepository context) : base(context)
        {
        }

    }
}
