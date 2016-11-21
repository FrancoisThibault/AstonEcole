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
    [RoutePrefix("api/Courses")]

    public class CourseController : ApiController
    {
        AstonApiClientCourse monAstonApiClientCourse;

        CourseController()
        {
            monAstonApiClientCourse = new AstonApiClientCourse();
        }

        [HttpGet]
        [ResponseType(typeof(IEnumerable<Course>))]
        public IHttpActionResult GetCourses()
        {
            return Ok(monAstonApiClientCourse.GetCourses());
        }

        [HttpGet]
        [ResponseType(typeof(Course))]
        public IHttpActionResult GetCourseById(int id)
        {
            return Ok(monAstonApiClientCourse.GetCourseById(id));
        }

        [HttpGet]
        [Route("NbEleves")]
        [ResponseType(typeof(IEnumerable<CourseWithNbStudents>))]
        public IHttpActionResult GetCoursesNBStudents()
        {
            return Ok(monAstonApiClientCourse.GetCourseNbEleves());
        }

        [HttpGet]
        [Route("searchByName/{matiere}")]
        [ResponseType(typeof(Boolean))]
        public IHttpActionResult GetStudents(string matiere)
        {
            return Ok(monAstonApiClientCourse.GetCourses().Select(c => c.Subject.Contains(matiere)));
        }

        [HttpPut]
        [ResponseType(typeof(void))]
        public IHttpActionResult UpdateCourse(int id, Course cours)
        {
            monAstonApiClientCourse.UpdateCourse(cours);

            return Ok();
        }

        [HttpPost]
        [ResponseType(typeof(void))]
        public IHttpActionResult PostCourse(Course cours)
        {
            monAstonApiClientCourse.AddCourse(cours);

            return Ok();
        }

        [HttpDelete]
        [ResponseType(typeof(void))]
        public IHttpActionResult DeleteCourse(int id)
        {
            monAstonApiClientCourse.DeleteCourse(id);

            return Ok();
        }

        [HttpPost]
        [Route("Create")]
        [ResponseType(typeof(void))]
        public IHttpActionResult PostCreateCourse()
        {
            monAstonApiClientCourse.CreateCourse();

            return Ok();
        }

        [HttpPut]
        [Route("UpdateStudents/{id}")]
        [ResponseType(typeof(IEnumerable<int>))]
        public IHttpActionResult UpdateStudents(Course selectedStudents)
        {
            monAstonApiClientCourse.UpdateCourse(selectedStudents);

            return Ok();
        }

        protected override void Dispose(bool disposing)
        {
            monAstonApiClientCourse.Dispose();
            base.Dispose(disposing);
        }
    }
}
