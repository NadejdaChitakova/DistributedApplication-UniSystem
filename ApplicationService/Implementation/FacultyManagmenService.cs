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
    public class FacultyManagmenService
    {
        UniDbContext context = new UniDbContext();
        public List<FacultyDTO> GetAllFaculty()
        {
            List<FacultyDTO> faculties = new List<FacultyDTO>();
            using (UnitOfWork unitOfWork = new UnitOfWork())
            {
                foreach (var item in unitOfWork.FacultyRepository.Get())
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

            }
            return faculties;
        }

        public FacultyDTO GetFacultyById(int id)
        {
            FacultyDTO facultyDTO = new FacultyDTO();
            using (UnitOfWork unitOfWork = new UnitOfWork())
            {
                Faculty faculty = unitOfWork.FacultyRepository.GetByID(id);
                if (faculty != null)
                {
                    facultyDTO.Id = faculty.Id;
                    facultyDTO.Name = faculty.Name;
                    facultyDTO.Dean = faculty.Dean;
                    facultyDTO.City = faculty.City;
                    facultyDTO.Profit = faculty.Profit;
                    facultyDTO.CountEmployees = faculty.CountEmployees;
                }
                return facultyDTO;
            }
        }
        public bool Save(FacultyDTO facultyDTO)
        {
            if (facultyDTO == null)
            {
                return false;
            }
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
                using (UnitOfWork unitOfWork = new UnitOfWork())
                {
                    unitOfWork.FacultyRepository.Insert(falculty);
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
                    Faculty faculty = unitOfWork.FacultyRepository.GetByID(id);
                    unitOfWork.FacultyRepository.Delete(faculty);
                    unitOfWork.Save();

                }

                return true;
            }
            catch
            {
                return false;
            }

        }
        public bool Edit(FacultyDTO facultyDTO)
        {
            try
            {
                Faculty faculty = new Faculty
                {
                    Id = facultyDTO.Id,
                    Name = facultyDTO.Name,
                    Dean = facultyDTO.Dean,
                    City = facultyDTO.City,
                    Profit = facultyDTO.Profit,
                    CountEmployees = facultyDTO.CountEmployees,
                };
                using (UnitOfWork unitOfWork = new UnitOfWork())
                {
                    unitOfWork.FacultyRepository.Update(faculty);
                    unitOfWork.Save();
                }
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }
        public FacultyDTO Details(int id)
        {
            FacultyDTO facultyDTO = new FacultyDTO();
            using (UnitOfWork unitOfWork = new UnitOfWork())
            {
                Faculty faculty = unitOfWork.FacultyRepository.GetByID(id);
                if (faculty != null)
                {
                    facultyDTO.Id = faculty.Id;
                    facultyDTO.Name = faculty.Name;
                    facultyDTO.Dean = faculty.Dean;
                    facultyDTO.City = faculty.City;
                    facultyDTO.Profit = faculty.Profit;
                    facultyDTO.CountEmployees = faculty.CountEmployees;
                }
                return facultyDTO;
            }
        }
    }
}
