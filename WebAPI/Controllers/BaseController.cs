using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebAPI.Controllers
{
    public class BaseController : ApiController
    {
        [HttpGet]
        public IHttpActionResult Version()
        {
            return Json("Our first Rest API - Version 0.1");
        }
    }
}
