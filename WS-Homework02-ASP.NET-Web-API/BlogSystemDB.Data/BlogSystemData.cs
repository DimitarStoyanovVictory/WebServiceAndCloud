using System;
using System.Collections.Generic;
using BlogSystem.Data.Repositories;
using BlogSystem.Models;

namespace BlogSystem.Data
{
    public class BlogSystemData : IBlogSystemData
    {
        private IBlogSystemDbContext _context;
        private IDictionary<Type, object> repositories; 

        public BlogSystemData(IBlogSystemDbContext context)
        {
            this._context = context;
            repositories = new Dictionary<Type, object>();
        }

        public IBlogSystemDbContext Context
        {
            get { return _context; }
        }

        public IUsersRepository Users
        {
            get { return (IUsersRepository)GetRepository<User>(); }
        }

        public IRepository<Post> Posts
        {
            get { return new GenericRepository<Post>(this._context); }
        }

        public IRepository<Comment> Comments
        {
            get { return new GenericRepository<Comment>(this._context); }
        }

        public IRepository<Tag> Tags
        {
            get { return new GenericRepository<Tag>(this._context); }
        }

        public int SaveChanges()
        {
            return this._context.SaveChanges();
        }

        private IRepository<T> GetRepository<T>() where T : class
        {
            var type = typeof(T);
            if (!this.repositories.ContainsKey(type))
            {
                var repositoryType = typeof(GenericRepository<T>);
                if (typeof(T).IsAssignableFrom(type))
                {
                    repositoryType = typeof(UsersRepository);
                }

                this.repositories.Add(typeof(T), Activator.CreateInstance(repositoryType, this._context));
            }

            return (IRepository<T>)this.repositories[type];
        }
    }
}
