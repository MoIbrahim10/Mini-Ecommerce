using Mini_E_commerce.Application.Interfaces.Repository.Base;
using Models;

namespace Mini_E_commerce.Application.Interfaces.Services.Base
{
    public interface IService<TClass> : IRepository<TClass> where TClass : class, IEntity
    {

    }

}
