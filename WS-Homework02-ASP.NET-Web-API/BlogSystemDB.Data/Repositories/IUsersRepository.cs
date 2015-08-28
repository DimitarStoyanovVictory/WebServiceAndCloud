using System.Linq;
using BlogSystem.Models;

namespace BlogSystem.Data.Repositories
{
    public interface IUsersRepository : IRepository<User>
    {
        IQueryable<User> AllAuthors();

        IQueryable<User> AllByGender(Gender gender);

        User GetUserByUsername(string username);
    }
}
