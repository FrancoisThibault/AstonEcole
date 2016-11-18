using AstonEcole.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace AstonEcole.ApiClient
{
    public class AstonApiClientCourse : AstonApiClient
    {
        /// <returns>GET, POST, PUT, DELETE</returns>
        public List<Course> GetCourses()
        {
            return GetAsync<List<Course>>($"api/Courses");
        }

        public Course GetCourseById(int id)
        {
            return GetAsync<Course>($"api/Courses/{id}");
        }

        public List<Boolean> GetCourseByNom(string matiere) // { Envoie un cours en fonction de sa matière }
        {
            return GetAsync<List<Boolean>>($"api/Courses/searchByName/{matiere}");
        }

        public List<CourseWithNbStudents> GetCourseNbEleves() // { Envoie cours avec nombre d'élèves }
        {
            return GetAsync<List<CourseWithNbStudents>>($"api/Courses/NbEleves");
        }

        public void UpdateCourse(Course cours) // { Mise à jour des cours }
        {
            astonSvc.PutAsJsonAsync<Course>($"api/Courses/{cours.Id}", cours).Wait();
        }

        public Course AddCourse(Course cours) // { Ajout de cours }
        {
            astonSvc.PostAsJsonAsync<Course>($"api/Courses/{cours.Id}", cours).Wait();
            return cours;
        }

        public void DeleteCourse(int id) // { Suppression de cours }
        {
            astonSvc.DeleteAsync($"api/Courses/{id}");
        }

        public Course CreateCourse() // { création de cours }
        {
            return GetAsync<Course>($"api/Courses/Create");
        }
    }
}