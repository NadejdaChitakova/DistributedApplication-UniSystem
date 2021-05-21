using ApplicationService.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC.ViewModels
{
    public class SpecialityVM
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
        [Required]
        public byte CountSubject { get; set; }
        [Required]
        public double Price { get; set; }
        [Required]
        [MaxLength(70)]
        public string InspectorName { get; set; }
        [Required]
        public byte Duration { get; set; }
        [Required]
        public int? FacultyId { get; set; }
        public FacultiesVM FacultiesVM { get; set; }
        public SpecialityVM() { }
        public SpecialityVM(SpecialityDTO specialityDto) {
            Id = specialityDto.Id;
            Name = specialityDto.Name;
            CountSubject = specialityDto.CountSubject;
            Price = specialityDto.Price;
            InspectorName = specialityDto.InspectorName;
            Duration = specialityDto.Duration;
            FacultyId = specialityDto.Id;
            //FacultiesVM = new FacultiesVM
            //{
            //    Id = specialityDto.Id,
            //   // Name = specialityDto.Name
            //};
            
        }
    }
}