using ApplicationService.DTO;
using Data.Context;
using Data.Entities;
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

            foreach (var item in ctx.Students.ToList())
            {
                students.Add(new StudentDTO{
                    Id = item.Id,
                    EGN = item.EGN,
                    FirstName = item.FirstName,
                    LastName = item.LastName,
                    SpecialityId = item.SpecialityId,
                    Speciality = new SpecialityDTO
                    {
                        Id = (int)item.SpecialityId,
                        Name = item.CurrentSpeciality.Name
                    }
                });
            }
            return students;
        }
        public StudentDTO GetById(int id)
        {
            Student item = ctx.Students.Find(id);

            StudentDTO studentDTO = new StudentDTO
            {
                Id = item.Id,
                EGN = item.EGN,
                FirstName = item.FirstName,
                LastName = item.LastName,
                SpecialityId = item.SpecialityId,
                Speciality = new SpecialityDTO
                {
                    Id = (int)item.SpecialityId,
                    Name = item.CurrentSpeciality.Name
                }
            };
            return studentDTO;
        }
        public bool Save(StudentDTO studentDTO)
        {
            if (studentDTO.Speciality == null || studentDTO.SpecialityId == 0 )
            {
                return false;
            }
            /* 
             * Speciality speciality = new Speciality { 
                Id= (int)studentDTO.SpecialityId,
                Name = studentDTO.Speciality.Name
            };
            */
            Student student = new Student { 
                EGN = studentDTO.EGN,
                FirstName = studentDTO.FirstName,
                LastName = studentDTO.LastName,
                PhoneNumber = studentDTO.PhoneNumber,
                DateOfBirth = studentDTO.DateOfBirth,
                SpecialityId = studentDTO.SpecialityId
                
            };
            try
            {
                ctx.Students.Add(student);
                ctx.SaveChanges();
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
                Student student = ctx.Students.Find(id);
                ctx.Students.Remove(student);
                ctx.SaveChanges();

                return true;
            }
            catch 
            {
                return false;
            }

        }
    }
}
