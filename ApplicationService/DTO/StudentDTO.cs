using Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationService.DTO
{
    public class StudentDTO
    {
        public int Id { get; set; }
        public int EGN { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int PhoneNumber { get; set; }
        public DateTime? DateOfBirth { get; set; }

        public int? SpecialityId { get; set; }
        public virtual SpecialityDTO Speciality { get; set; }

    }
}
