using BlogSystem.Data.Repositories;
using BlogSystem.Models;

namespace BlogSystem.Data
{
    public interface IBlogSystemData
    {
        IUsersRepository Users { get; }

        IRepository<Post> Posts { get; }

        IRepository<Comment> Comments { get; }

        IRepository<Tag> Tags { get; }

        int SaveChanges();
    }
}
