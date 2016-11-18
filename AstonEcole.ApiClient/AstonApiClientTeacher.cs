using AstonEcole.DTO;
using AstonEcole.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace AstonEcole.ApiClient
{
    public class AstonApiClientTeacher : AstonApiClient
    {

        public Teacher getTeacher(int id)
        {
            return GetAsync<Teacher>($"api/Teachers/{id}");
        }

        public List<Teacher> getTeachers()
        {
            return GetAsync<List<Teacher>>("api/Teachers");
        }

        public List<TeacherWithNbCourses> LoadTeachersWithNbCourses()
        {
            return GetAsync<List<TeacherWithNbCourses>>("api/Teachers/TeacherCourses");
        }

        public void UpdateCourse(Teacher teacher , IEnumerable<int> courses)
        {
            astonSvc.PutAsJsonAsync<Teacher>($"api/Teaches/{teacher.Id}",teacher).Wait();
        }

        public List<Student> GetStudents()
        {
            return GetAsync<List<Student>>($"api/Students/");
        }

    }
}