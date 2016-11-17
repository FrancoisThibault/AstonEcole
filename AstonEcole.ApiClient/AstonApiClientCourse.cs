using AstonEcole.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace AstonEcole.ApiClient
{
    class AstonApiClientCourse : AstonApiClient
    {

        public async Task<List<Course>> GetCourses()
        {
            List<Course> courses = null;
            HttpResponseMessage response = await astonSvc.GetAsync($"api/Courses");
            if (response.IsSuccessStatusCode)
            {
                courses = await response.Content.ReadAsAsync<List<Course>>();
            }

            return courses;
        }

        public async Task<Course> GetCourseById(int id)
        {
            Course course = null;
            HttpResponseMessage response = await astonSvc.GetAsync($"api/Courses/{id}");
            if (response.IsSuccessStatusCode)
            {
                course = await response.Content.ReadAsAsync<Course>();
            }

            return course;
        }

        
        public async Task<List<Boolean>> GetCourseByNom(string matiere) 
        {
            List<Boolean> Listes = null;
            HttpResponseMessage response = await astonSvc.GetAsync($"api/Courses/searchByName/{matiere}");
            if (response.IsSuccessStatusCode)
            {
                Listes = await response.Content.ReadAsAsync<List<Boolean>>();
            }
            return Listes;
        }

        

    }
}
