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

        public List<Teacher> getTeachers()
        {
            return GetAsync<List<Teacher>>("api/Teachers");
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

    }
}