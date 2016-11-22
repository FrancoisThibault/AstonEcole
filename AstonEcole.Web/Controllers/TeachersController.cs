using AstonEcole.ApiClient;
using AstonEcole.DTO;
using AstonEcole.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;

namespace AstonEcole.Web.Controllers
{
    [RoutePrefix("api/Teachers")]
    public class TeachersController : ApiController
    {
        AstonApiClientTeacher monAstonApiClientTeacher;
    
        public TeachersController()
        {
            monAstonApiClientTeacher = new AstonApiClientTeacher();
        }

        [HttpGet]
        [ResponseType(typeof(IEnumerable<Teacher>))]
        public IHttpActionResult GetTeachers()
        {
            return Ok(monAstonApiClientTeacher.getTeachers());
        }

        [HttpGet]
        [ResponseType(typeof(IEnumerable<Teacher>))]
        public IHttpActionResult GetTeacher(int id)
        {
            return Ok(monAstonApiClientTeacher.getTeacher(id));
        }


    }
}
