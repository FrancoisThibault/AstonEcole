using AstonEcole.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AstonEcole.DTO
{
    public class CourseWithNbStudents
    {
        public CourseWithNbStudents() { }

        public CourseWithNbStudents(Course course)
        {
            NbStudents = course.Students.Count;
            course.Students = null;
            if (course.Teacher != null)
            {
                course.Teacher.Courses = null;
            }

            Course = course;
        }

        public Course Course { get; set; }
        public int NbStudents { get; set; }
    }
}
