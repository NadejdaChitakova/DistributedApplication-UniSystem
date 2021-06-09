using ApplicationService.DTO;
using java.lang;
using MVC.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Object = System.Object;

namespace MVC.Controllers
{
    public class StudentController : Controller
    {
        // GET: Student
        [HttpGet]
        public ActionResult Index(string searchEGN)
        {
            List<StudentVM> studentVM = new List<StudentVM>();
            using (SoapService.Service1Client service = new SoapService.Service1Client()){
                foreach (var item in service.GetStudents())
                {
                    studentVM.Add(new StudentVM(item));
                }
            }

            if (searchEGN != null)
            {
                int egn = Integer.parseInt(searchEGN);
                Object currentEGN = studentVM.Where(x => x.EGN == egn);
                return View(currentEGN);
            }
            return View(studentVM);
        }
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
                    using (SoapService.Service1Client service = new SoapService.Service1Client())
                    {
                        StudentDTO studentDTO = new StudentDTO
                        {
                            FirstName = studentVM.FirstName,
                            LastName = studentVM.LastName,
                            EGN = studentVM.EGN,
                            DateOfBirth = studentVM.DateOfBirth,
                            PhoneNumber = studentVM.PhoneNumber,
                            SpecialityId = (int)studentVM.SpecialityId
                       
                        };
                        service.PostStudent(studentDTO);
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
        [HttpGet]

        public ActionResult Edit(int id)
        {
            StudentVM studentVM;
            ViewBag.Specialities = Helper.LoadDataUnilities.LoadSpecialities();
            using (SoapService.Service1Client service = new SoapService.Service1Client())
            {
               
                StudentDTO studentDTO = service.GetStudentById(id);
                studentVM = new StudentVM
                {
                    EGN = studentDTO.EGN,
                    FirstName = studentDTO.FirstName,
                    LastName = studentDTO.LastName,
                    DateOfBirth = (DateTime)studentDTO.DateOfBirth,
                    PhoneNumber = studentDTO.PhoneNumber,
                    SpecialityId = studentDTO.SpecialityId
                };

                

            }
            return View(studentVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(StudentVM studentVM)
        {
            if (ModelState.IsValid)
            {
                using (SoapService.Service1Client service = new SoapService.Service1Client())
                {
                    StudentDTO studentDTO = new StudentDTO
                    {
                        Id = studentVM.Id,
                        FirstName = studentVM.FirstName,
                        LastName = studentVM.LastName,
                        PhoneNumber = studentVM.PhoneNumber,
                        EGN = studentVM.EGN,
                        DateOfBirth = studentVM.DateOfBirth,
                        SpecialityId = studentVM.SpecialityId
                    };
                    service.EditStudent(studentDTO);

                }
            }
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Details(int id)
        {
            StudentVM studentVM;
            using (SoapService.Service1Client service = new SoapService.Service1Client())
            {

                StudentDTO studentDTO = service.GetStudentById(id);
                studentVM = new StudentVM
                {
                    
                    EGN = studentDTO.EGN,
                    FirstName = studentDTO.FirstName,
                    LastName = studentDTO.LastName,
                    DateOfBirth = (DateTime)studentDTO.DateOfBirth,
                    PhoneNumber = studentDTO.PhoneNumber,
                    SpecialityId = studentDTO.SpecialityId
                };



            }
            return View(studentVM);
        }

    }
}