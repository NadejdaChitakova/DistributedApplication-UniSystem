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
    public class FacultyManagmenService
    {
        UniDbContext context = new UniDbContext();
        public List<FacultyDTO> GetAllFaculty()
        {
            List<FacultyDTO> faculties = new List<FacultyDTO>();

            foreach (var item in context.Faculties.ToList())
            {
                faculties.Add(new FacultyDTO
                {
                    Id = item.Id,
                    Name = item.Name,
                    Dean = item.Dean,
                    City = item.City,
                    Profit = item.Profit,
                    CountEmployees = item.CountEmployees
                });
            }
            return faculties;
        }
        public bool Save(FacultyDTO facultyDTO)
        {
            Faculty falculty = new Faculty
            {
                Id = facultyDTO.Id,
                Name = facultyDTO.Name,
                Dean = facultyDTO.Dean,
                City = facultyDTO.City,
                Profit = facultyDTO.Profit,
                CountEmployees = facultyDTO.CountEmployees
            };
            try
            {
                context.Faculties.Add(falculty);
                context.SaveChanges();
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
                Faculty faculty = context.Faculties.Find(id);
                context.Faculties.Remove(faculty);
                context.SaveChanges();

                return true;
            }
            catch
            {
                return false;
            }

        }

    }
}
