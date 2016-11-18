using AstonEcole.ApiClient;
using AstonEcole.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;

namespace AstonEcole.Web.Controllers
{
    [RoutePrefix("api/Students")]
    public class StudentsController : ApiController
    {

        AstonApiClientStudent monAstonApiClientStudent;

        public StudentsController()
        {
            monAstonApiClientStudent = new AstonApiClientStudent();
        }

        [HttpGet]
        [ResponseType(typeof(IEnumerable<Student>))]
        public IHttpActionResult GetStudents()
        {
            return Ok(monAstonApiClientStudent.GetStudents());
        }

        [HttpGet] 
        [ResponseType(typeof(Student))]
        public IHttpActionResult GetStudent(int id)
        {
            return Ok(monAstonApiClientStudent.GetStudent(id));
        }

        protected override void Dispose(bool disposing)
        {
            monAstonApiClientStudent.Dispose();
            base.Dispose(disposing);
        }


    }
}
