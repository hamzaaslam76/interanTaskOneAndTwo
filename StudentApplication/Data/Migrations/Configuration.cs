namespace Data.Migrations
{
    using Models.DataModels;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Data.Context.context>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Data.Context.context context)
        {
            if(!context.courses.Any() &&!context.users.Any()&&!context.roles.Any()&&!context.userRoles.Any())
            {
                context.courses.AddRange(new List<Course> { 
                new Course {CourseName="Math"},
                new Course {CourseName="English"},
                new Course {CourseName="Urdu"},
                new Course {CourseName="OOP"},
                new Course {CourseName="Asp.Net"},



                });
                var getRoleId = context.roles.AddRange(new List<Role>
                {
                  new Role {Title="SuperAdmin"},
                  new Role {Title="Admin"}
                });
                context.SaveChanges();
                var getUserId = context.users.Add(new User
                {
                    Name = "Hamza Aslam",
                    Email = "Hamza@gmail.com",
                    Phone = "03316531746",
                    Password = "Hamza12@"

                });
                context.userRoles.Add(
                    new UserRole
                    {
                        UserId = getUserId.UserId,
                        RoleId = getRoleId.Where(r => r.Title == "SuperAdmin").First().RoleId
                    });
                context.SaveChanges();


            }
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.
        }
    }
}
