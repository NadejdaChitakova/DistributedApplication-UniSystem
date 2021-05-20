using ApplicationService.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC.Controllers
{
    public class FacultyController : Controller
    {
        // GET: Faculty
        public ActionResult Index()
        {
            List<FacultyDTO> facultyDTOs = new List<FacultyDTO>();

            using (SoapService.Service1Client service = new SoapService.Service1Client())
            {
                foreach (var item in service.GetFaculties())
                {
                    facultyDTOs.Add(item);
                }
            }
                return View(facultyDTOs);
        }
    }
}