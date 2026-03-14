using Mediator.Model;
using Mediator.Repositories.Abstraction;

namespace Mediator.Repositories
{
    public class InMemoryUserRepository : IUserRepository
    {
        public User GetById(int id)
        {
            return new User()
            {
                Id = 1,
                Email = "a@a.pl",
                IsActive = true
            };
        }
    }
}
