using AstonEcole.Api.Infrastructure;
using AstonEcole.DTO;
using AstonEcole.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;

namespace AstonEcole.Api.Controllers
{
    [RoutePrefix("api/Courses")]
    public class CoursesController : BaseApiController<CoursesServices>
    {
        [HttpGet]
        [ResponseType(typeof(IEnumerable<Course>))]
        public IHttpActionResult GetCourses()
        {
            return Ok(Service.LoadCourses());
        }

        //[HttpGet]
        //[ResponseType(typeof(IEnumerable<Course>))]
        //public IHttpActionResult GetCoursesWithNBStudents()
        //{
        //    return Ok(Service.LoadCoursesWithNbStudents());
        //}

        [HttpGet]
        [ResponseType(typeof(Course))]
        public IHttpActionResult GetStudent(int id)
        {
            return Ok(Service.LoadCourse(id));
        }

        [HttpGet]
        [Route("searchByName/{matiere}")]
        [ResponseType(typeof(IEnumerable<Course>))]
        public IHttpActionResult GetStudents(string matiere)
        {
            return Ok(Service.LoadCourses().Select(c => c.Subject.Contains(matiere)));
        }

        [HttpPut]
        [ResponseType(typeof(void))]
        public IHttpActionResult UpdateStudent(int id, Course cours)
        {
            Service.UpdateCourses(cours);
            Service.Save();

            return Ok();
        }

        [HttpPost]
        [ResponseType(typeof(void))]
        public IHttpActionResult PostCourse(Course cours)
        {
            Service.AddCourses(cours);
            Service.Save();

            return Ok();
        }

        [HttpDelete]
        [ResponseType(typeof(void))]
        public IHttpActionResult DeleteCourse(int id)
        {
            Service.DeleteCourses(id);
            Service.Save();

            return Ok();
        }
    }
}
