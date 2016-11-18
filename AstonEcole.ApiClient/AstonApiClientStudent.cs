using AstonEcole.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace AstonEcole.ApiClient
{
    public class AstonApiClientStudent : AstonApiClient
    {
        

        public Student GetStudent(int id)
        {
            return GetAsync<Student>($"api/Students/{id}");
        }

        public List<Student> GetStudents()
        {
            return GetAsync<List<Student>>($"api/Students");
        }

        public List<StudentNbCours> GetStudentsWithNbCours()
        {
            return GetAsync<List<StudentNbCours>>($"api/Students/WithNbCours");
        }

        public void UpdateStudent(Student student)
        {
            HttpResponseMessage response = astonSvc.PutAsJsonAsync<Student>($"api/Students/{student.Id}", student).Result;
            if (response.IsSuccessStatusCode)
            {
                student = response.Content.ReadAsAsync<Student>().Result;
            }
        }

    }
}
