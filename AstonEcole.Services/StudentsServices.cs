using AstonEcole.DTO;
using AstonEcole.Services.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Text;
using System.Threading.Tasks;

namespace AstonEcole.Services
{
    public class StudentsServices : BaseServices
    {
        public Student LoadStudent(int id)
        {
            return Context.Students.Include(s => s.Courses).Include("Courses.Teacher").Single(s => s.Id == id);
        }
        
        public IEnumerable<Student> LoadStudents(int courseId)
        {
            return Context.Courses.Where(c => c.Id == courseId).SelectMany(c => c.Students);
        }

        public IEnumerable<Student> LoadStudents()
        {
            return LoadStudents(s => true);
        }

        public IEnumerable<Student> LoadStudents(Func<Student, bool> filter)
        {
            return Context.Students.Where(filter);
        }

        public void SaveStudent(Student student)
        {
            Context.Entry<Student>(student).State = EntityState.Modified;
        }
    }
}