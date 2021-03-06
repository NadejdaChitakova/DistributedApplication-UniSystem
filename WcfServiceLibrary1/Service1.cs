using ApplicationService.DTO;
using ApplicationService.Implementation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WcfServiceLibrary1
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in both code and config file together.
    public class Service1 : IService1
    {
        private StudentManagmentService studentService = new StudentManagmentService();
        private FacultyManagmenService facultyService = new FacultyManagmenService();
        private SpecialityManagmentService specialityServicce = new SpecialityManagmentService();
        public string GetData(int value)
        {
            return string.Format("You entered: {0}", value);
        }

        public CompositeType GetDataUsingDataContract(CompositeType composite)
        {
            if (composite == null)
            {
                throw new ArgumentNullException("composite");
            }
            if (composite.BoolValue)
            {
                composite.StringValue += "Suffix";
            }
            return composite;
        }
        //------------------------------------------------ 
        public List<StudentDTO> GetStudents()
        {
            return studentService.GetAllStudent();
        }
        public StudentDTO GetStudentById(int id)
        {
            return studentService.GetById(id);
        }
        public string PostStudent(StudentDTO studentDTO)
        {
            if (!studentService.Save(studentDTO))
            {
                return "Student is not saved";
            }
            else
            {
                return "Student is saved";
            }
        }
        public string DeleteStudent(int id)
        {
            if (!studentService.Delete(id))
            {
                return "Student is not deleted";
            }
            else
            {
                return "Student is deleted.";
            }
        }

        public string EditStudent(StudentDTO studentDTO)
        {
            if (studentService.Edit(studentDTO))
            {
                return "Student is edited.";
            }
            else
            {
                return "Student is not edited";
            }
        }

        //------------------------------------------------ 
        public List<FacultyDTO> GetFaculties()
        {
            return facultyService.GetAllFaculty();
        }

        public string PostFaculty(FacultyDTO facultyDTO)
        {
            if (!facultyService.Save(facultyDTO))
            {
                return "Faculty is not saved.";
            }
            else
            {
                return "Faculty is saved.";
            }
        }

        public string DeleteFaculty(int value)
        {
            if (!facultyService.Delete(value))
            {
                return "Faculty is not deleted.";
            }
            else
            {
                return "Faculty is deleted.";
            }
        }
        public FacultyDTO GetFacultyByID(int id)
        {
            return facultyService.GetFacultyById(id);
        }

        public string EditFaculty(FacultyDTO facultyDTO)
        {
            if (facultyService.Edit(facultyDTO))
            {
                return "Faculty is edited";
            }
            else
            {
                return "Faculty is not edited.";
            }
        }
        //------------------------------------------------ 
        public List<SpecialityDTO> GetSpecialities()
        {
            return specialityServicce.GetSpecialities();
        }
        
        public string PostSpeciality(SpecialityDTO specialityDTO)
        {
            if (!specialityServicce.Save(specialityDTO))
            {
                return "Speciality is not saved.";
            }
            else
            {
                return "Speciality is saved.";
            }
        }

        public string DeleteSpeciality(int value)
        {
            if (!specialityServicce.Delete(value))
            {
                return "Speciality is not saved.";
            }
            else
            {
                return "Speciality is saved.";
            }
        }

        public SpecialityDTO GetSpecialityById(int id)
        {
            return specialityServicce.getById(id);
        }

        public string EditSpeciality(SpecialityDTO specialityDTO)
        {
            if (specialityServicce.Edit(specialityDTO))
            {
                return "Speciality is edited.";
            }
            else
            {
                return "Speciality is not edited.";
            }
        }

        public StudentDTO DetailsStudent(int id)
        {
            throw new NotImplementedException();
        }

        public FacultyDTO DetailsFaculty(int id)
        {
            return facultyService.Details(id);
        }

        public SpecialityDTO DetailsSpeciality(int id)
        {
            return specialityServicce.Details(id);
        }
    }
}
