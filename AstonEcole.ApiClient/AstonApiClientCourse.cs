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
        #region PHILLIPE
        /// <summary>
        /// Methode de PHILLIPE
        /// </summary>
        /// <returns></returns>
        //public async Task<List<Course>> GetCourses() // { Renvoie la liste des cours }
        //{
        //    List<Course> courses = null;
        //    HttpResponseMessage response = await astonSvc.GetAsync($"api/Courses");
        //    if (response.IsSuccessStatusCode)
        //    {
        //        courses = await response.Content.ReadAsAsync<List<Course>>();
        //    }

        //    return courses;
        //}

        //public async Task<Course> GetCourseById(int id) // { Envoie un cours en fonction de son Id }
        //{
        //    Course course = null;
        //    HttpResponseMessage response = await astonSvc.GetAsync($"api/Courses/{id}");
        //    if (response.IsSuccessStatusCode)
        //    {
        //        course = await response.Content.ReadAsAsync<Course>();
        //    }

        //    return course;
        //}

        //public async Task<List<Boolean>> GetCourseByNom(string matiere) // { Envoie un cours en fonction de sa matière }
        //{
        //    List<Boolean> Listes = null;
        //    HttpResponseMessage response = await astonSvc.GetAsync($"api/Courses/searchByName/{matiere}");
        //    if (response.IsSuccessStatusCode)
        //    {
        //        Listes = await response.Content.ReadAsAsync<List<Boolean>>();
        //    }
        //    return Listes;
        //}

        //public async Task<List<CourseWithNbStudents>> GetCourseNbEleves() // { Envoie cours avec nombre d'élèves }
        //{
        //    List<CourseWithNbStudents> ListesNbEleves = null;
        //    HttpResponseMessage response = await astonSvc.GetAsync($"api/Courses/NbEleves");
        //    if (response.IsSuccessStatusCode)
        //    {
        //        ListesNbEleves = await response.Content.ReadAsAsync<List<CourseWithNbStudents>>();
        //    }

        //    return ListesNbEleves;
        //}

        //public void UpdateCourse(Course cours) // { Mise à jour des cours }
        //{
        //    astonSvc.PutAsJsonAsync<Course>($"api/Courses/{cours.Id}", cours).Wait();
        //}

        //public async Task<Course> AddCourse(Course cours) // { Ajout de cours }
        //{
        //    Course AddEleve = null;
        //    HttpResponseMessage response = await astonSvc.PostAsJsonAsync<Course>($"api/Courses/{cours.Id}", cours);
        //    if (response.IsSuccessStatusCode)
        //    {
        //        AddEleve = await response.Content.ReadAsAsync<Course>();
        //    }

        //    return AddEleve;
        //}

        //public void DeleteCourse(int id) // { Suppression de cours }
        //{
        //    astonSvc.DeleteAsync($"api/Courses/{id}");
        //}
        #endregion

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

        public List<CourseWithNbStudents> GetCourseNbEleves() // { Envoie cours avec nombre d'élèves }
        {
            return GetAsync<List<CourseWithNbStudents>>($"api/Courses/NbEleves");
        }

        public void UpdateCourse(Course cours) // { Mise à jour des cours }
        {
            astonSvc.PutAsJsonAsync<Course>($"api/Courses/{cours.Id}", cours).Wait();
        }

        public void AddCourse(Course cours) // { Ajout de cours }
        {
            astonSvc.PostAsJsonAsync<Course>($"api/Courses/{cours.Id}", cours).Wait();
        }

        public void CreateCourse() // { Création de cours }
        {
            astonSvc.GetAsync($"api/Courses/Create").Wait();
        }

        public void DeleteCourse(int id) // { Suppression de cours }
        {
            astonSvc.DeleteAsync($"api/Courses/{id}");
        }
        #endregion


    }
}
