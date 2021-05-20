using ApplicationService.DTO;
using MVC.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC.Controllers
{
    public class SpecialityController : Controller
    {
        // GET: Speciality
        public ActionResult Index()
        {
            List<SpecialityVM> list = new List<SpecialityVM>();

            using(SoapService.Service1Client service = new SoapService.Service1Client())
            {
                foreach (var item in service.GetSpecialities())
                {
                    list.Add(new SpecialityVM(item));
                }
            }
            return View(list);
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(SpecialityVM specialityVM)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using(SoapService.Service1Client service = new SoapService.Service1Client())
                    {
                        SpecialityDTO specialityDTO = new SpecialityDTO
                        {
                            Name = specialityVM.Name,
                            CountSubject = specialityVM.CountSubject,
                            Price = specialityVM.Price,
                            InspectorName = specialityVM.InspectorName,
                            Duration = specialityVM.Duration

                        };
                        service.PostSpeciality(specialityDTO);
                        return RedirectToAction("Index");
                    }
                }
                return View();
            }
            catch 
            {

                return View();
            }
        }
    }
}