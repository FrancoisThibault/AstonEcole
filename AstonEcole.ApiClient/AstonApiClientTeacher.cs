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
    public class AstonEcoleApiClient : IDisposable
    {
        private HttpClient astonSvc;

        public AstonEcoleApiClient()
        {
            astonSvc = new HttpClient();
            astonSvc.BaseAddress = new Uri("http://localhost:56089/");
            astonSvc.DefaultRequestHeaders.Clear();
            astonSvc.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

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

        #region 
        /// <summary>
        /// Region des Cours !
        /// </summary>
        /// <returns>GET, POST, PUT, DELETE</returns>
        public List<Course> GetCourses() // { Renvoie la liste des cours }
        {
            return GetAsync<List<Course>>($"api/Courses");
        }

        public Course GetCourseById(int id) // { Envoie un cours en fonction de son Id }
        {
            return GetAsync<Course>($"api/Courses/{id}");
        }

        public List<Boolean> GetCourseByNom(string matiere) // { Envoie un cours en fonction de sa matière }
        {
            return GetAsync<List<Boolean>>($"api/Courses/searchByName/{matiere}");
        }

        public void UpdateCourse(Course cours) // { Mise à jour des cours }
        {
            astonSvc.PutAsJsonAsync<Course>($"api/Courses/{cours.Id}", cours).Wait();
        }

        public void AddCourse(Course cours) // { Ajout de cours }
        {
            astonSvc.PostAsJsonAsync<Course>($"api/Courses/{cours.Id}", cours).Wait();
        }

        public void DeleteCourse(int id) // { Suppression de cours }
        {
            astonSvc.DeleteAsync($"api/Courses/{id}");
        }
        #endregion


        public List<Student> GetStudents()
        {
            return GetAsync<List<Student>>($"api/Students/");
        }

        private TResult GetAsync<TResult>(string api)
            where TResult: class, new()
        {
            Task<HttpResponseMessage> response = astonSvc.GetAsync(api);

            var x = response.Result.Content.ReadAsStringAsync().Result;

            JavaScriptSerializer sera = new JavaScriptSerializer();
            TResult result = sera.Deserialize<TResult>(x);
            return result;
        }

        public void Dispose()
        {
            if (astonSvc != null)
            {
                astonSvc.Dispose();
            }
        }
    }
}