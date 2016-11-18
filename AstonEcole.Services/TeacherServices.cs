using AstonEcole.DAL;
using AstonEcole.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Text;
using System.Threading.Tasks;
using AstonEcole.Services.Infrastructure;

namespace AstonEcole.Services
{
    public class TeacherServices : BaseServices
    {
        public TeacherServices() : base() { }
        public TeacherServices(BaseServices otherService) : base(otherService) { }

        public IEnumerable<Teacher> LoadTeachers()
        {
            return LoadTeachers(t => true);
        }

        private IEnumerable<Teacher> LoadTeachers(Func<Teacher, bool> filter)
        {
            return Context.Teachers.Where(filter);
        }

        
        public Teacher LoadTeacher(int id)
        {
            return LoadTeacher(t => t.Id == id);
        }

        private Teacher LoadTeacher(Func<Teacher, bool> filter)
        {
            return Context.Teachers.Include(prof => prof.Courses).SingleOrDefault(filter);
        }

        public IEnumerable<TeacherWithNbCourses> LoadTeachersWithNbCourses()
        {
            return Context.Teachers.GroupJoin(
                Context.Courses,
                t => t.Id,
                c => c.Teacher.Id,
                (tdd, cs) => new TeacherWithNbCourses() { Teacher = tdd, NbCourses = cs.Count() });
        }

        public void UpdateTeacher(int id , Teacher teacher)
        {
            Teacher teacherInMemory = Context.Teachers.Where(v => v.Id == id).Single();
            teacherInMemory.Name = teacher.Name;
            
        }

        
        public void UpdateTeacherCourses(int Teacherid , IEnumerable<int> selectedCourses)
        {
            Teacher teacherInDb = Context.Teachers.Include(V=>V.Courses).Single(v => v.Id == Teacherid);

            if (selectedCourses == null)
            {
                selectedCourses = new List<int>();
            }

            teacherInDb.Courses.Where(c => !selectedCourses.Contains(c.Id)).ToList()
                .ForEach(c => teacherInDb.Courses.Remove(c));

            /*selectedCourses.Where(id => !teacherInDb.Courses.Any(c => c.Id == Teacherid)).ToList()
                .ForEach(id => teacherInDb.Courses.Add(Context.Courses.Single(c => c.Id == id)));*/

            foreach(int i in selectedCourses)
            {
                Course course = Context.Courses.Single(a=>a.Id==i);
                if (!teacherInDb.Courses.Contains(course))
                { teacherInDb.Courses.Add(course); }
            }


            Save();
        }




    }
}
