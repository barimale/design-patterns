using Mediator.Model;

namespace Mediator.Repositories.Abstraction
{
    public interface IUserRepository
    {
        User GetById(int id);
    }
}
