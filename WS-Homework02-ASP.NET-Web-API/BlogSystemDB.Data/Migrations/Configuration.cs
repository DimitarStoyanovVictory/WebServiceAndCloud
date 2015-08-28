using BlogSystem.Data;
using System.Data.Entity.Migrations;

namespace BlogSystemDB.Data.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<BlogSystemDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(BlogSystemDbContext context)
        {
        }
    }
}
