using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using BlogSystem.Models;

namespace BlogSystem.Data
{
    public interface IBlogSystemDbContext
    {
        IDbSet<User> Users { get; set; }

        IDbSet<Post> Posts { get; set; }

        IDbSet<Comment> Comments { get; set; }

        IDbSet<Tag> Tags { get; set; }

        int SaveChanges();

        DbEntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class;

        IDbSet<T> Set<T>() where T : class;
    }
}
