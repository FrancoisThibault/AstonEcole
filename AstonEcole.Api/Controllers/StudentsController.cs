using AstonEcole.Api.Infrastructure;
using AstonEcole.DTO;
using AstonEcole.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Web.Http;
using System.Web.Http.Description;

namespace AstonEcole.Api.Controllers
{
    [RoutePrefix("api/Students")]
    public class StudentsController : BaseApiController<StudentsServices>
    {
        [HttpGet]
        [ResponseType(typeof(IEnumerable<Student>))]
        public IHttpActionResult GetStudents()
        {
            return Ok(Service.LoadStudents());
        }

        [HttpGet]
        [ResponseType(typeof(Student))]
        public IHttpActionResult GetStudent(int id)
        {
            return Ok(Service.LoadStudent(id));
        }

        [HttpGet]
        [Route("searchByName/{name}")]
        [ResponseType(typeof(IEnumerable<Student>))]
        public IHttpActionResult GetStudents(string name)
        {
            return Ok(Service.LoadStudents(s => s.FirstName.Contains(name)));
        }

        [HttpGet]
        [Route("WithNbCours/")]
        [ResponseType(typeof(IEnumerable<StudentNbCours>))]
        public IHttpActionResult GetStudentsWithNbCours()
        {
            return Ok(Service.LoadStudentsWithNbCours());
        }

        [HttpPut]
        [ResponseType(typeof(void))]
        public IHttpActionResult UpdateStudent(int id, Student student)
        {
            Service.SaveStudent(student);
            Service.Save();

            return Ok();
        }
    }
}