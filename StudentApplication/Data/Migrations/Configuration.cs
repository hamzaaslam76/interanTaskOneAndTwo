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
            if(!context.courses.Any())
            {
                 context.courses.AddRange(new List<Course> { 
                new Course {CourseName="Math"},
                new Course {CourseName="English"},
                new Course {CourseName="Urdu"},
                new Course {CourseName="OOP"},
                new Course {CourseName="Asp.Net"},



                });
                context.SaveChanges();


            }
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.
        }
    }
}
