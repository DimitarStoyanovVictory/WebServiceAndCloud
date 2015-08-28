using System.Data.Entity;
using BlogSystem.Models;
using BlogSystemDB.Data.Migrations;

namespace BlogSystem.Data
{
    public class BlogSystemDbContext : DbContext, IBlogSystemDbContext
    {
        public BlogSystemDbContext()
            : base("BlogSystemDB")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<BlogSystemDbContext, Configuration>());
        }

        public IDbSet<User> Users { get; set; }

        public IDbSet<Post> Posts { get; set; }

        public IDbSet<Comment> Comments { get; set; }

        public IDbSet<Tag> Tags { get; set; }

        public new IDbSet<T> Set<T>() where T : class
        {
            return base.Set<T>();
        }
    }
}
