using AstonEcole.DTO;
using AstonEcole.Services;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using System.Web.UI;


namespace AstonEcole.ApiClient
{
    public class AstonEcoleApiClient
    {
        private HttpClient astonSvc = new HttpClient();

        public AstonEcoleApiClient()
        {
            astonSvc.BaseAddress = new Uri("http://localhost:56089/");
            astonSvc.DefaultRequestHeaders.Clear();
            astonSvc.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public void UpdateStudent(Student student)
        {
            astonSvc.PutAsJsonAsync<Student>($"api/Students/{student.Id}", student).Wait();
        }

        public Student GetStudent(int id)
        {
            return GetAsync<Student>($"api/Students/{id}");
        }

        public Teacher getTeacher(int id)
        {
            return GetAsync<Teacher>($"api/Teachers/{id}");
        }


        public async Task<List<Teacher>> getTeachers()
        {
            List<Teacher> Teachers = null;
            HttpResponseMessage response = await astonSvc.GetAsync("api/Teachers");
            if (response.IsSuccessStatusCode)
            {
                Teachers = await response.Content.ReadAsAsync<List<Teacher>>();
            }

        #region 
        /// <summary>
        /// Region des Cours !
        /// </summary>
        /// <returns>GET, POST, PUT, DELETE</returns>
        public List<Course> GetCourses() // { Renvoie la liste des cours }
        {
            return GetAsync<List<Course>>($"api/Courses");
        }

            return Teachers;    
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


        public Course GetCourseById(int id) // { Envoie un cours en fonction de son Id }
        {
            return GetAsync<Course>($"api/Courses/{id}");
        }

        public List<Boolean> GetCourseByNom(string matiere) // { Envoie un cours en fonction de sa matière }
        {
            return GetAsync<List<Boolean>>($"api/Courses/searchByName/{matiere}");
        }

        public void UpdateCourse(Course cours)
        {
            astonSvc.PutAsJsonAsync<Course>($"api/Students/{cours.Id}", cours).Wait();
        }
        #endregion

        private TResult GetAsync<TResult>(string api)
            where TResult: class, new()
        {
            Task<HttpResponseMessage> response = astonSvc.GetAsync(api);

            var x = response.Result.Content.ReadAsStringAsync().Result;

            JavaScriptSerializer sera = new JavaScriptSerializer();
            TResult result = sera.Deserialize<TResult>(x);
            return result;
        }
    }
}