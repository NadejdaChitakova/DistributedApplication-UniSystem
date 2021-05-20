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
    public class SpecialityManagmentService
    {

        private UniDbContext ctx = new UniDbContext();

        public List<SpecialityDTO> GetSpecialities()
        {
            List<SpecialityDTO> specialities = new List<SpecialityDTO>();

            foreach (var item in ctx.Specialties.ToList())
            {
                specialities.Add(new SpecialityDTO
                {
                    Id = item.Id,
                    Name = item.Name,
                    Duration = item.Duration,
                    Price = item.Price,
                    InspectorName = item.InspectorName,
                    CountSubject = item.CountSubject,
                    FacultyId = item.FacultyId,
                    CurrentFaculty = new FacultyDTO
                    {
                        Id = item.Id,
                        Name = item.Name
                    }
                });
            }
            return specialities;
        }
        public bool Save(SpecialityDTO specialityDTO)
        {
            Speciality speciality = new Speciality
            {
                Name = specialityDTO.Name,
                Duration = specialityDTO.Duration,
                Price = specialityDTO.Price,
                InspectorName = specialityDTO.InspectorName,
                CountSubject = specialityDTO.CountSubject,
                FacultyId = specialityDTO.FacultyId
            };
            try
            {
                ctx.Specialties.Add(speciality);
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
                Speciality speciality = ctx.Specialties.Find(id);
                ctx.Specialties.Remove(speciality);
                ctx.SaveChanges();

                return true;
            }
            catch
            {
                return false;
            }

        }
        //Edit
    }
}
