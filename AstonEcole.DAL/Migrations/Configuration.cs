namespace AstonEcole.DAL.Migrations
{
    using DTO;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<AstonEcole.DAL.AstonEcoleContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(AstonEcole.DAL.AstonEcoleContext context)
        {
            Teacher alain = new Teacher() { Id = 1, Name = "Alain" };
            Teacher francois = new Teacher() { Id = 2, Name = "François" };

            context.Teachers.AddOrUpdate(t => t.Id, alain, francois);

            Course webforms = new Course() { Id = 1, Subject = "Web", Teacher = alain };
            Course poo = new Course() { Id = 2, Subject = "Objet", Teacher = francois };
            Course entity = new Course() { Id = 3, Subject = "DAL", Teacher = francois };

            context.Courses.AddOrUpdate(c => c.Id, webforms, poo, entity);

            Student myriam = new Student() { Id = 1, FirstName = "Myriam", Courses = new List<Course>() { webforms, poo } };
            Student mario = new Student() { Id = 2, FirstName = "Mario", Courses = new List<Course>() { webforms, poo, entity } };
            Student philippe = new Student() { Id = 3, FirstName = "Philippe", Courses = new List<Course>() { poo } };

            context.Students.AddOrUpdate(e => e.Id, myriam, mario, philippe);
        }
    }
}
