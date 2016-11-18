using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace AstonEcole.Web.Infrastructure
{
    public class BaseApiController
    {

      /*  [EnableCors(origins: "http://localhost:51767", headers: "*", methods: "*")]
        public abstract class BaseApiController<TService> : ApiController
            where TService : BaseServices, new()
        {
            protected TService Service { get; private set; }

            protected BaseApiController()
            {
                Service = new TService();
            }

            protected override void Dispose(bool disposing)
            {
                if (disposing)
                {
                    if (Service != null)
                    {
                        //Service.Dispose();
                    }
                }

                base.Dispose(disposing);
            }
        }*/
    }
}