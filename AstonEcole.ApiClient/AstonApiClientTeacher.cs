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
    class AstonApiClientTeacher : AstonApiClient
    {
        

        public async Task<Teacher> getTeacher(int id)
        {
            Teacher teacher = null;
            HttpResponseMessage response = await astonSvc.GetAsync($"api/Teachers/{id}");
            if (response.IsSuccessStatusCode)
            {
                teacher = await response.Content.ReadAsAsync<Teacher>();
            }

            return teacher;
        }


        public async Task<List<Teacher>> getTeachers()
        {
            List<Teacher> Teachers = null;
            HttpResponseMessage response = await astonSvc.GetAsync("api/Teachers");
            if (response.IsSuccessStatusCode)
            {
                Teachers = await response.Content.ReadAsAsync<List<Teacher>>();
            }

            return Teachers;
        }


        public async Task<List<Course>> GetCourses() 
        {
            List<Course> Courses = null;
            HttpResponseMessage response = await astonSvc.GetAsync("api/Courses");
            if (response.IsSuccessStatusCode)
            {
                Courses = await response.Content.ReadAsAsync<List<Course>>();
            }

            return Courses;
        }



        public async Task<IEnumerable<TeacherWithNbCourses>> LoadTeachersWithNbCourses()
        {
            IEnumerable<TeacherWithNbCourses> TeacherWithNbCour = null;
            HttpResponseMessage response = await astonSvc.GetAsync("api/Teachers/TeacherCourses");
            if (response.IsSuccessStatusCode)
            {
                TeacherWithNbCour = await response.Content.ReadAsAsync<IEnumerable<TeacherWithNbCourses>>();
            }

            return TeacherWithNbCour;
        }


        
    

   
}
}
