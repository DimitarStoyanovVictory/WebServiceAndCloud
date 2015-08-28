﻿using System.Linq;
using BlogSystem.Models;

namespace BlogSystem.Data.Repositories
{
    public class UsersRepository : GenericRepository<User>, IUsersRepository
    {
        public UsersRepository(IBlogSystemDbContext context) 
            : base(context)
        {
        }

        public IQueryable<User> AllAuthors()
        {
            return this.All().Where(x => x.Posts.Any());
        }

        public IQueryable<User> AllByGender(Gender gender)
        {
            return this.All().Where(x => x.Gender == gender);
        }

        public User GetUserByUsername(string username)
        {
            return this.All().FirstOrDefault(x => x.Username == username);
        }
    }
}
