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
        public ActionResult Index(String name)
        {
            List<SpecialityVM> list = new List<SpecialityVM>();

            using(SoapService.Service1Client service = new SoapService.Service1Client())
            {
                foreach (var item in service.GetSpecialities())
                {
                    list.Add(new SpecialityVM(item));
                }
                if (name != null)
                {
                    Object currentName = list.Where(x => x.Name == name);
                    return View(currentName);
                }
            }
            return View(list);
        }
        public ActionResult Create()
        {
            ViewBag.Faculties = Helper.LoadDataUnilities.LoadFaculties();
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
                            // Id = specialityVM.Id,
                            Name = specialityVM.Name,
                            CountSubject = specialityVM.CountSubject,
                            Price = specialityVM.Price,
                            InspectorName = specialityVM.InspectorName,
                            Duration = specialityVM.Duration,
                            FacultyId = (int)specialityVM.FacultyId,
                            
                        };
                        service.PostSpeciality(specialityDTO);
                        return RedirectToAction("Index");
                    }
                }
                return View();
            }
            catch 
            {
                ViewBag.Faculties = Helper.LoadDataUnilities.LoadFaculties();
                return View();
            }
        }
        public ActionResult Delete(int id)
        {

            using (SoapService.Service1Client service = new SoapService.Service1Client())
            {
                service.DeleteSpeciality(id);
            }
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            SpecialityVM specialityVM;
            ViewBag.Faculties = Helper.LoadDataUnilities.LoadFaculties();
            using (SoapService.Service1Client service = new SoapService.Service1Client())
            {
                SpecialityDTO specialityDTO = service.GetSpecialityById(id);
                specialityVM = new SpecialityVM
                {
                    Name = specialityDTO.Name,
                    CountSubject = specialityDTO.CountSubject,
                    Duration = specialityDTO.Duration,
                    Price = specialityDTO.Price,
                    InspectorName = specialityDTO.InspectorName,
                    FacultyId = specialityDTO.FacultyId,
                };
            }
                return View(specialityVM);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(SpecialityVM specialityVM)
        {

            if (ModelState.IsValid)
            {
                using (SoapService.Service1Client service = new SoapService.Service1Client())
                {
                    SpecialityDTO specialityDTO = new SpecialityDTO
                    {
                        Id = specialityVM.Id,
                        Name = specialityVM.Name,
                        CountSubject = specialityVM.CountSubject,
                        Duration = specialityVM.Duration,
                        Price = specialityVM.Price,
                        InspectorName = specialityVM.InspectorName,
                        FacultyId = (int)specialityVM.FacultyId
                    };
                    service.EditSpeciality(specialityDTO);

                }
            }
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Details(int id)
        {

            SpecialityVM specialityVM;
            
            using (SoapService.Service1Client service = new SoapService.Service1Client())
            {
                SpecialityDTO specialityDTO = service.GetSpecialityById(id);
                specialityVM = new SpecialityVM
                {
                    Name = specialityDTO.Name,
                    CountSubject = specialityDTO.CountSubject,
                    Duration = specialityDTO.Duration,
                    Price = specialityDTO.Price,
                    InspectorName = specialityDTO.InspectorName,
                    FacultyId = specialityDTO.FacultyId,
                };
            }
            return View(specialityVM);
        }
    }
}