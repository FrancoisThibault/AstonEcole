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
    public class CoursesServices : BaseServices
    {
        public Course CreateCourse()
        {
            Course newCourse = new Course();
            newCourse.Students = new List<Student>();
            //Context.Courses.Add(newCourse);
            Context.Entry<Course>(newCourse).State = EntityState.Added;
            return newCourse;
        }

        public IEnumerable<Course> LoadCourses()
        {
            return LoadCourses(c => true);
        }

        private IEnumerable<Course> LoadCourses(Func<Course, bool> filter)
        {
            return Context.Courses.Include(c => c.Teacher).Where(filter);
        }

        public Course LoadCourse(int id)
        {
            return Context.Courses.Include(c => c.Teacher).Single(c => c.Id == id);
        }

        public IEnumerable<CourseWithNbStudents> LoadCoursesWithNbStudents()
        {
            return Context.Courses.Include(c => c.Teacher).Include(c => c.Students).ToList()
                .Select(c => new CourseWithNbStudents(c));
        }

        public void UpdateStudents(Course selectedCourse, IEnumerable<int> selectedStudents)
        {
            if (selectedStudents == null)
            {
                selectedStudents = new List<int>();
            }

            selectedCourse.Students.Where(s => !selectedStudents.Contains(s.Id)).ToList()
                .ForEach(s => selectedCourse.Students.Remove(s));

            selectedStudents.Where(id => !selectedCourse.Students.Any(s => s.Id == id)).ToList()
                .ForEach(id => selectedCourse.Students.Add(Context.Students.Single(s => s.Id == id)));
        }

        public void UpdateStudents(int id, IEnumerable<int> selectedStudents)
        {
            if (selectedStudents == null)
            {
                selectedStudents = new List<int>();
            }

            var cours = Context.Courses.Include(s => s.Students).Single(c => c.Id == id);

            cours.Students.Where(s => !selectedStudents.Contains(s.Id)).ToList()
                .ForEach(s => Context.Entry<Student>(s).State = EntityState.Deleted);

            selectedStudents.Where(ids => !cours.Students.Any(s => s.Id == ids)).ToList()
                .ForEach(ids => Context.Entry<Student>((Context.Students.Single(s => s.Id == ids))).State = EntityState.Added);
        }

        public void UpdateCourses(Course cours)
        {
            Context.Entry<Course>(cours).State = EntityState.Modified;
        }

        public void AddCourses(Course cours)
        {
            Context.Entry<Course>(cours).State = EntityState.Added;
        }

        public void DeleteCourses(int id)
        {
            Course cours = LoadCourse(id);
            Context.Entry<Course>(cours).State = EntityState.Deleted;
        }
    }
}