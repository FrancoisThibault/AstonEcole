using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace AstonEcole.Web.Controllers
{
    public class TestController : ApiController
    {
        public string GetDateJour()
        {
            return DateTime.Now.ToString("dd MM yyyy");
        }
    }
}
