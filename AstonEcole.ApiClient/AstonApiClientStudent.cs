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

        public async Task UpdateStudent(Student student)
        {
            HttpResponseMessage response = await astonSvc.PutAsJsonAsync<Student>($"api/Students/{student.Id}", student);
            if (response.IsSuccessStatusCode)
            {
                student = await response.Content.ReadAsAsync<Student>();
            }
        }

    }
}
