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

        public void UpdateCourses(Teacher teacher, IEnumerable<int> selectedCourses)
        {
            if (selectedCourses == null)
            {
                selectedCourses = new List<int>();
            }

            teacher.Courses.Where(c => !selectedCourses.Contains(c.Id)).ToList()
                .ForEach(c => teacher.Courses.Remove(c));

            selectedCourses.Where(id => !teacher.Courses.Any(c => c.Id == id)).ToList()
                .ForEach(id => teacher.Courses.Add(Context.Courses.Single(c => c.Id == id)));

            Save();
        }




    }
}
