using ApplicationService.DTO;
using ApplicationService.Implementation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebAPI1.Messages;

namespace WebAPI1.Controllers
{
    [RoutePrefix("api/students")]
    public class StudentController :BaseController
    {
        private readonly StudentManagmentService _service = null;
        public StudentController()
        {
            _service = new StudentManagmentService();
        }
        [HttpGet]
        [Route("")]
        public IHttpActionResult Get()
        {
            return Json(_service.GetAllStudent());
        }
        [HttpGet]
        [Route("{id}")]
        public IHttpActionResult Get(int id)
        {
            return Json(_service.GetById(id));
        }
        [HttpPost]
        public IHttpActionResult Save(StudentDTO studentDTO)
        {
            ResponseMessages response = new ResponseMessages();
            if (_service.Save(studentDTO))
            {
                response.Code = 201;
                response.Body = "Student has been saved";
            }
            else
            {
                response.Code = 200;
                response.Body = "Student has not been saved";
            }
            return Json(response);
        }
        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            ResponseMessages response = new ResponseMessages();
            if (_service.Delete(id))
            {
                response.Code = 200;
                response.Body = "Student has been deleted";
            }
            else
            {
                response.Code = 200;
                response.Body = "Student has not been deleted";
            }
            return Json(response);
        }
    }
}
