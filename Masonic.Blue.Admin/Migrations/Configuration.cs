using Masonic.Blue.Models;

namespace Masonic.Blue.Admin.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Masonic.Blue.Admin.Models.MasonicDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Masonic.Blue.Admin.Models.MasonicDbContext context)
        {
            context.LodgeTypes.AddOrUpdate(
                b => b.Type,
                new LodgeType { Id = Guid.NewGuid(), Type = "Blue Lodge", DateCreated = DateTime.Now, DateModified = DateTime.Now },
                new LodgeType { Id = Guid.NewGuid(), Type = "York Rite", DateCreated = DateTime.Now, DateModified = DateTime.Now },
                new LodgeType { Id = Guid.NewGuid(), Type = "Scottish Rite", DateCreated = DateTime.Now, DateModified = DateTime.Now },
                new LodgeType { Id = Guid.NewGuid(), Type = "Shriners", DateCreated = DateTime.Now, DateModified = DateTime.Now },
                new LodgeType { Id = Guid.NewGuid(), Type = "Jobs Daughters", DateCreated = DateTime.Now, DateModified = DateTime.Now },
                new LodgeType { Id = Guid.NewGuid(), Type = "Tall Cedars", DateCreated = DateTime.Now, DateModified = DateTime.Now },
                new LodgeType { Id = Guid.NewGuid(), Type = "DeMolay", DateCreated = DateTime.Now, DateModified = DateTime.Now });

            context.BodyTypes.AddOrUpdate(
                l => l.Type,
                new BodyType { Id = Guid.NewGuid(), Type = "N/A", DateCreated = DateTime.Now, DateModified = DateTime.Now },
                new BodyType { Id = Guid.NewGuid(), Type = "Royal Arch Mason", DateCreated = DateTime.Now, DateModified = DateTime.Now },
                new BodyType { Id = Guid.NewGuid(), Type = "Council", DateCreated = DateTime.Now, DateModified = DateTime.Now },
                new BodyType { Id = Guid.NewGuid(), Type = "Commandery", DateCreated = DateTime.Now, DateModified = DateTime.Now });
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
        }
    }
}
