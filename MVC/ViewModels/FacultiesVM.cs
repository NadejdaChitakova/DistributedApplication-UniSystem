using ApplicationService.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC.ViewModels
{
    public class FacultiesVM
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
        [Required]
        [MaxLength(70)]
        public string Dean { get; set; }
        [Required]
        [MaxLength(25)]
        public string City { get; set; }
        public double Profit { get; set; }
        public int CountEmployees { get; set; }
        public FacultiesVM() { }
        public FacultiesVM(FacultyDTO facultyDTO)
        {
            Id = facultyDTO.Id;
            Name = facultyDTO.Name;
            Dean = facultyDTO.Dean;
            City = facultyDTO.City;
            Profit = facultyDTO.Profit;
            CountEmployees = facultyDTO.CountEmployees;
        }
    }
}