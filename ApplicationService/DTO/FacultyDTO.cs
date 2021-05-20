using Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationService.DTO
{
    public class FacultyDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Dean { get; set; }
        public string City { get; set; }
        public double Profit { get; set; }
        public int CountEmployees { get; set; }

    }
}
