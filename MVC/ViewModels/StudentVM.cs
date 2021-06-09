using ApplicationService.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Web;

namespace MVC.ViewModels
{
    public class StudentVM
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "You must provide a phone number")]
        public int EGN { get; set; }

        [Required]
        [MaxLength(20)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(20)]
        public string LastName { get; set; }
        [Display(Name ="Date of birth")]
        [DataType(DataType.Date)]
        public DateTime? DateOfBirth { get; set; }

        [DataType(DataType.PhoneNumber)]
        public int PhoneNumber { get; set; }

        [Required]
        public int? SpecialityId { get; set; }
        public SpecialityVM specialityVM { get; set; }

        public StudentVM () { }
        public StudentVM (StudentDTO studentDTO) {
            Id = studentDTO.Id;
            EGN = studentDTO.EGN;
            FirstName = studentDTO.FirstName;
            LastName = studentDTO.LastName;
            DateOfBirth = studentDTO.DateOfBirth;
            PhoneNumber = studentDTO.PhoneNumber;
            SpecialityId = studentDTO.SpecialityId;
            //specialityVM = new SpecialityVM
            //{
            //    Id = studentDTO.Id,
            //    Name = studentDTO.CurrentSpeciality.Name
            //};
        }
    }
}