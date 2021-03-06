using ApplicationService.DTO;
using MVC.SoapService;
using MVC.ViewModels;
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
        public ActionResult Index(string name)
        {
            List<FacultiesVM> facultyDTOs = new List<FacultiesVM>();

            using (SoapService.Service1Client service = new SoapService.Service1Client())
            {
                foreach (var item in service.GetFaculties())
                {
                    facultyDTOs.Add(new FacultiesVM(item));
                }
            }
            if (name != null)
            {
                Object currentName = facultyDTOs.Where(x => x.Name == name);
                return View(currentName);
            }
            return View(facultyDTOs);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(FacultiesVM facultiesVM)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (SoapService.Service1Client service = new SoapService.Service1Client())
                    {
                        FacultyDTO facultyDTO = new FacultyDTO
                        {
                            Name = facultiesVM.Name,
                            Dean = facultiesVM.Dean,
                            City = facultiesVM.City,
                            Profit = facultiesVM.Profit,
                            CountEmployees = facultiesVM.CountEmployees
                        };
                        service.PostFaculty(facultyDTO);
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
        public ActionResult Delete(int id)
        {

            using (SoapService.Service1Client service = new SoapService.Service1Client())
            {
                service.DeleteFaculty(id);
            }
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            FacultiesVM facultiesVM;

            using (SoapService.Service1Client service = new Service1Client())
            {
                FacultyDTO facultyDTO = service.GetFacultyByID(id);
                facultiesVM = new FacultiesVM
                {
                    Name = facultyDTO.Name,
                    City = facultyDTO.City,
                    CountEmployees = facultyDTO.CountEmployees,
                    Dean = facultyDTO.Dean,
                    Profit = facultyDTO.Profit,
                };
            }
            return View(facultiesVM);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(FacultiesVM facultiesVM)
        {
                if (ModelState.IsValid)
                {

                    using (SoapService.Service1Client service = new SoapService.Service1Client())
                    {
                        FacultyDTO facultyDTO = new FacultyDTO
                        {
                            Id = facultiesVM.Id,
                            City = facultiesVM.City,
                            CountEmployees = facultiesVM.CountEmployees,
                            Dean = facultiesVM.Dean,
                            Profit = facultiesVM.Profit
                        };
                        service.EditFaculty(facultyDTO);

                    }
                }
            return RedirectToAction("Index");
        }
        public ActionResult Details(int id)
        {
            FacultiesVM facultiesVM;

            using (SoapService.Service1Client service = new Service1Client())
            {
                FacultyDTO facultyDTO = service.GetFacultyByID(id);
                facultiesVM = new FacultiesVM
                {
                    Name = facultyDTO.Name,
                    City = facultyDTO.City,
                    CountEmployees = facultyDTO.CountEmployees,
                    Dean = facultyDTO.Dean,
                    Profit = facultyDTO.Profit,
                };
            }
            return View(facultiesVM);
        }
    }
}