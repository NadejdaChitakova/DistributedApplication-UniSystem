using ApplicationService.DTO;
using MVC.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC.Controllers
{
    public class StudentController : Controller
    {
        // GET: Student
        public ActionResult Index()
        {
            List<StudentVM> studentsVM = new List<StudentVM>();
            using (SoapService.Service1Client service = new SoapService.Service1Client()){
                foreach (var item in service.GetStudents())
                {
                    studentsVM.Add(new StudentVM(item));
                }
            }
            return View(studentsVM);
        }
        [HttpGet]
        public ActionResult Create()
        {
            ViewBag.Specialities = Helper.LoadDataUnilities.LoadSpecialities();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(StudentVM studentVM)
        {
            try { 
            
                if (ModelState.IsValid)
                {
                    using (SoapService.Service1Client client = new SoapService.Service1Client())
                    {
                        StudentDTO studentDTO = new StudentDTO
                        {
                            FirstName = studentVM.FirstName,
                            LastName = studentVM.LastName,
                            EGN = studentVM.EGN,
                            DateOfBirth = studentVM.DateOfBirth,
                            PhoneNumber = studentVM.PhoneNumber,
                            SpecialityId = (int)studentVM.SpecialityId,
                        //    CurrentSpeciality = new SpecialityDTO
                        //    {
                        //        Id = (int)studentVM.SpecialityId,
                        //        Name = studentVM.specialityVM.Name
                        //    }
                        };
                        client.PostStudent(studentDTO);
                        return RedirectToAction("Index");
                    }
                }
                return View();
            }
            catch
            {
                ViewBag.Specialities = Helper.LoadDataUnilities.LoadSpecialities();
                return View();

            }
            
        }

        public ActionResult Delete(int id)
        {
            
            using (SoapService.Service1Client service = new SoapService.Service1Client())
            {
                service.DeleteStudent(id);
            }
            return RedirectToAction("Index");
        }
    }
}