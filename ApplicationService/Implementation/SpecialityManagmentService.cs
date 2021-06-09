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
    public class SpecialityManagmentService
    {

        private UniDbContext ctx = new UniDbContext();

        public List<SpecialityDTO> GetSpecialities()
        {
            List<SpecialityDTO> specialities = new List<SpecialityDTO>();

            using (UnitOfWork unitOfWork = new UnitOfWork())
            {
                foreach (var item in unitOfWork.SpecialityRepository.Get())
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
            }
            return specialities;
        }
        public SpecialityDTO getById(int id)
        {
            SpecialityDTO specialityDTO = new SpecialityDTO();

            using (UnitOfWork unitOfWork = new UnitOfWork())
            {
                Speciality speciality = unitOfWork.SpecialityRepository.GetByID(id);
                if (speciality != null)
                {
                    specialityDTO.Id = speciality.Id;
                    specialityDTO.Name = speciality.Name;
                    specialityDTO.Duration = speciality.Duration;
                    specialityDTO.Price = speciality.Price;
                    specialityDTO.InspectorName = speciality.InspectorName;
                    specialityDTO.CountSubject = speciality.CountSubject;
                    specialityDTO.FacultyId = speciality.FacultyId;
                }
                return specialityDTO;
            }
        }
        public bool Save(SpecialityDTO specialityDTO)
        {
            //if (specialityDTO.Id == 0)
            //{
            //    return false;
            //}
            Speciality speciality = new Speciality
            {
                Name = specialityDTO.Name,
                Duration = specialityDTO.Duration,
                Price = specialityDTO.Price,
                InspectorName = specialityDTO.InspectorName,
                CountSubject = specialityDTO.CountSubject,
                FacultyId = specialityDTO.FacultyId,
                //Faculty = new Faculty
                //{
                //    Id = specialityDTO.Id,
                //    Name = specialityDTO.Name
                //}
            };
            try
            {
                using (UnitOfWork unitOfWork = new UnitOfWork())
                {
                    unitOfWork.SpecialityRepository.Insert(speciality);
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
                    Speciality speciality = unitOfWork.SpecialityRepository.GetByID(id);
                    unitOfWork.SpecialityRepository.Delete(speciality);
                    unitOfWork.Save();
                }

                return true;
            }
            catch
            {
                return false;
            }

        }
        public bool Edit(SpecialityDTO specialityDTO)
        {
            try
            {
                Speciality speciality = new Speciality
                {
                    Id = specialityDTO.Id,
                    Name = specialityDTO.Name,
                    Duration = specialityDTO.Duration,
                    Price = specialityDTO.Price,
                    InspectorName = specialityDTO.InspectorName,
                    CountSubject = specialityDTO.CountSubject,
                    FacultyId = specialityDTO.FacultyId,
                };
                using (UnitOfWork unitOfWork = new UnitOfWork())
                {
                    unitOfWork.SpecialityRepository.Update(speciality);
                    unitOfWork.Save();
                }
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }
        public SpecialityDTO Details(int id)
        {
            SpecialityDTO specialityDTO = new SpecialityDTO();

            using (UnitOfWork unitOfWork = new UnitOfWork())
            {
                Speciality speciality = unitOfWork.SpecialityRepository.GetByID(id);
                if (speciality != null)
                {
                    specialityDTO.Id = speciality.Id;
                    specialityDTO.Name = speciality.Name;
                    specialityDTO.Duration = speciality.Duration;
                    specialityDTO.Price = speciality.Price;
                    specialityDTO.InspectorName = speciality.InspectorName;
                    specialityDTO.CountSubject = speciality.CountSubject;
                    specialityDTO.FacultyId = speciality.FacultyId;
                }
                return specialityDTO;
            }
        }
    }
}
