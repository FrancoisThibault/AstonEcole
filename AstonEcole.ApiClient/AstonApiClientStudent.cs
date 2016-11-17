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
        

        public async Task<Student> GetStudent(int id)
        {
            Student student=null;
            HttpResponseMessage response = await astonSvc.GetAsync($"api/Students/{id}");
            if (response.IsSuccessStatusCode)
            {
                student = await response.Content.ReadAsAsync<Student>();
            }

            return student;
        }

        public async Task<List<Student>> GetStudents()
        {
            List<Student> student = null;
            HttpResponseMessage response = await astonSvc.GetAsync($"api/Students");
            if (response.IsSuccessStatusCode)
            {
                student = await response.Content.ReadAsAsync<List<Student>>();
            }
            return student;
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
