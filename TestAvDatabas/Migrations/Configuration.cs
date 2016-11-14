namespace TestAvDatabas.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using TestAvDatabas.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<TestAvDatabas.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(TestAvDatabas.Models.ApplicationDbContext context)
        {

            IceCream iceCream1 = new IceCream { IceCreamId = 1, Name = "TopHat", Students = new List<Student>() };
            IceCream iceCream2 = new IceCream { IceCreamId = 2, Name = "Nogger", Students = new List<Student>() };

            context.IceCreams.AddOrUpdate(
                i => i.IceCreamId,
                iceCream1,
                iceCream2
                

                );


            context.Standards.AddOrUpdate(

                s => s.StandardId,
                new Standard { StandardId = 1, StandardName = "Svenska", Students = new List<Student>(), Teachers = new List<Teacher>() },
                new Standard { StandardId = 2, StandardName = "Engelska", Students = new List<Student>(), Teachers = new List<Teacher>() },
                new Standard { StandardId = 3, StandardName = "Matematik", Students = new List<Student>(), Teachers = new List<Teacher>() }

                );

            context.Students.AddOrUpdate(
                s => s.StudentID,
                new Student { StudentID = 1, StudentName = "Kalle", StandardId = 1, IceCream = new List<IceCream>() },
                new Student { StudentID = 2, StudentName = "Lisa", StandardId = 1, IceCream = new List<IceCream>() },
                new Student { StudentID = 3, StudentName = "Anna", StandardId = 1, IceCream = new List<IceCream>() }

                );




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
