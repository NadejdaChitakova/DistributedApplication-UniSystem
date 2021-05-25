﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebAPI1.Controllers
{
    public class BaseController : ApiController
    {
        [HttpGet]
        public IHttpActionResult Version()
        {
            return Json("Web APIversion 0.1");
        }
    }
}
