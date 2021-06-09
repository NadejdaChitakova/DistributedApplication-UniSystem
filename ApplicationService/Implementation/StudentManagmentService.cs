using ApplicationService.DTO;
using Data.Context;
using Data.Entities;
using Reposiory.Implementations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationService.Implementation
{
    public class StudentManagmentService
    {
        private UniDbContext ctx = new UniDbContext();

        public List<StudentDTO> GetAllStudent()
        {
            List<StudentDTO> students = new List<StudentDTO>();

            using (UnitOfWork unitOfWork = new UnitOfWork())
            {
                foreach (var item in unitOfWork.StudentRepository.Get())
                {
                    students.Add(new StudentDTO
                    {
                        Id = item.Id,
                        EGN = item.EGN,
                        FirstName = item.FirstName,
                        LastName = item.LastName,
                        PhoneNumber = item.PhoneNumber,
                        SpecialityId = (int)item.SpecialityId,
                        CurrentSpeciality = new SpecialityDTO
                        {
                            Id = item.Id,
                            Name = item.CurrentSpeciality.Name
                        }
                    });
                    }
            }
                return students;
        }
        public StudentDTO GetById(int id)
        {
            StudentDTO item = new StudentDTO();

            using (UnitOfWork unitOfWork = new UnitOfWork())
            {
               
                Student student = unitOfWork.StudentRepository.GetByID(id);
                if (student != null)
                {
                    item.Id = student.Id;
                    item.EGN = student.EGN;
                    item.FirstName = student.FirstName;
                    item.DateOfBirth = student.DateOfBirth;
                    item.LastName = student.LastName;
                    item.PhoneNumber = student.PhoneNumber;
                    item.SpecialityId = student.SpecialityId;
                    //item.CurrentSpeciality = new SpecialityDTO
                    //{
                    //    Id = (int)student.SpecialityId,
                    //    Name = item.CurrentSpeciality.Name
                    //};
                }
                return item;
            }
        }
        public bool Save(StudentDTO studentDTO)
        {
        //    if ( studentDTO.SpecialityId == 0 )
        //    {
        //        return false;
        //    }

                Student student = new Student {
                EGN = studentDTO.EGN,
                FirstName = studentDTO.FirstName,
                LastName = studentDTO.LastName,
                PhoneNumber = studentDTO.PhoneNumber,
                DateOfBirth = (DateTime)studentDTO.DateOfBirth,
                SpecialityId = studentDTO.SpecialityId,                
            };
            try
            {
                using (UnitOfWork unitOfWork = new UnitOfWork()) {

                    unitOfWork.StudentRepository.Insert(student);
                    unitOfWork.Save();
                }

                return true;
            }
            catch 
            { 
                return false;
            }
        }
        public bool Delete(int id)
        {
            try
            {
                using (UnitOfWork unitOfWork = new UnitOfWork())
                {
                    Student student = unitOfWork.StudentRepository.GetByID(id);
                    unitOfWork.StudentRepository.Delete(student);
                    unitOfWork.Save();

                }
                return true;
            }
            catch 
            {
                return false;
            }

        }
        public bool Edit(StudentDTO studentDTO)
        {
            try
            {
                Student student = new Student
                {
                    Id = studentDTO.Id,
                    EGN = studentDTO.EGN,
                    FirstName = studentDTO.FirstName,
                    LastName = studentDTO.LastName,
                    PhoneNumber = studentDTO.PhoneNumber,
                    DateOfBirth = (DateTime)studentDTO.DateOfBirth,
                    SpecialityId = studentDTO.SpecialityId,

                };
                using (UnitOfWork unitOfWork = new UnitOfWork())
                {
                    unitOfWork.StudentRepository.Update(student);
                    unitOfWork.Save();
                }
                return true;
            }
            catch
            {
                return false;
            }
        }
        public StudentDTO Details(int id)
        {
            StudentDTO item = new StudentDTO();

            using (UnitOfWork unitOfWork = new UnitOfWork())
            {

                Student student = unitOfWork.StudentRepository.GetByID(id);
                if (student != null)
                {
                    item.Id = student.Id;
                    item.EGN = student.EGN;
                    item.FirstName = student.FirstName;
                    item.LastName = student.LastName;
                    item.PhoneNumber = student.PhoneNumber;
                    item.SpecialityId = student.SpecialityId;
                  
                }
                return item;
            }
        }
    }
}
