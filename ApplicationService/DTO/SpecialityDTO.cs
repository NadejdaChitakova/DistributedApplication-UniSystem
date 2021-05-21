using Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationService.DTO
{
    public class SpecialityDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public byte CountSubject { get; set; }
        public double Price { get; set; }
        public string InspectorName { get; set; }
        public byte Duration { get; set; }
        public int FacultyId { get; set; }
        public virtual FacultyDTO CurrentFaculty { get; set; }

    }
}
