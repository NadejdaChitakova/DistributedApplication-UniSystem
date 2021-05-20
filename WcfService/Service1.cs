using ApplicationService.DTO;
using ApplicationService.Implementation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WcfService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in both code and config file together.
    public class Service1 : IService1
    {
        private StudentManagmentService studentService = new StudentManagmentService();

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

        public List<StudentDTO> GetStudents() => studentService.GetAllStudent();

        public string PostStudent(StudentDTO studentDTO)
        {
            if (!studentService.Save(studentDTO))
            {
                return "You isnt save student.";
            }
            else
            {
                return "You  is save student";
            }
        }
        public string DeleteStudent(int id)
        {
            if (!studentService.Delete(id))
            {
                return "You isnt delete student.";
            }
            else
            {
                return "You delete student";
            }
        }

    }
}
