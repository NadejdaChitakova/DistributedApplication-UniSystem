using ApplicationService.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WcfServiceLibrary1
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IService1
    {
        [OperationContract]
        string GetData(int value);

        [OperationContract]
        CompositeType GetDataUsingDataContract(CompositeType composite);
        //------------------------------------------------ 
        // TODO: Add your service operations here
        [OperationContract]
        List<StudentDTO> GetStudents();

        [OperationContract]
        StudentDTO GetStudentById(int id);

        [OperationContract]
        string PostStudent(StudentDTO studentDTO);
        [OperationContract]
        string DeleteStudent(int value);
        [OperationContract]
        string EditStudent(StudentDTO studentDTO);
        [OperationContract]
        StudentDTO DetailsStudent(int id);
        //------------------------------------------------ 
        [OperationContract]
        List<FacultyDTO> GetFaculties();

        [OperationContract]
        string PostFaculty(FacultyDTO facultyDTO);
        [OperationContract]
        string DeleteFaculty(int value);
        [OperationContract]
        FacultyDTO GetFacultyByID(int id);
        [OperationContract]
        string EditFaculty(FacultyDTO facultyDTO);
        [OperationContract]
        FacultyDTO DetailsFaculty(int id);
        //------------------------------------------------

        [OperationContract]
        List<SpecialityDTO> GetSpecialities();

        [OperationContract]
        SpecialityDTO GetSpecialityById(int id);

        [OperationContract]
        string PostSpeciality(SpecialityDTO specialityDTO);
        [OperationContract]
        string DeleteSpeciality(int value);
        [OperationContract]
        string EditSpeciality(SpecialityDTO specialityDTO );
        [OperationContract]
        SpecialityDTO DetailsSpeciality(int id);
    }

    // Use a data contract as illustrated in the sample below to add composite types to service operations.
    // You can add XSD files into the project. After building the project, you can directly use the data types defined there, with the namespace "WcfServiceLibrary1.ContractType".
    [DataContract]
    public class CompositeType
    {
        bool boolValue = true;
        string stringValue = "Hello ";

        [DataMember]
        public bool BoolValue
        {
            get { return boolValue; }
            set { boolValue = value; }
        }

        [DataMember]
        public string StringValue
        {
            get { return stringValue; }
            set { stringValue = value; }
        }
    }
}
