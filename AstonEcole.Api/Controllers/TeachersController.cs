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
    [RoutePrefix("api/Teachers")]
    public class TeachersController : BaseApiController<TeacherServices>
    {
        [HttpGet]
        [ResponseType(typeof(IEnumerable<Teacher>))]
        public IHttpActionResult GetTeachers()
        {
            return Ok(Service.LoadTeachers());
        }

        [HttpGet]
        [ResponseType(typeof(Teacher))]
        public IHttpActionResult GetTeacher(int id)
        {
            return Ok(Service.LoadTeacher(id));
        }

        [Route("TeacherCourses")]
        [HttpGet]
        [ResponseType(typeof(IEnumerable<TeacherWithNbCourses>))]
        public IHttpActionResult LoadTeachersWithNbCourses()
        {
            return Ok(Service.LoadTeachersWithNbCourses());
        }


        [HttpPut]
        [ResponseType(typeof(void))]
        public void UpdateTeacher(int id , Teacher teacher)
        {
            Service.UpdateTeacher(id , teacher);
            Service.Save();
        }

        [Route("UTeacherCourses/{id}")]
        [HttpPut]
        [ResponseType(typeof(void))]
        public void UpdateTeacherCourses(int id, IEnumerable<int> courses)
        {
            Service.UpdateTeacherCourses(id, courses);
            Service.Save();
        }


    }
}
