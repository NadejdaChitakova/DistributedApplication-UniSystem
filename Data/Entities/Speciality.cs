using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities
{
    public class Speciality
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public byte CountSubject { get; set; }
        public double Price { get; set; }
        public string InspectorName { get; set; }
        public byte Duration { get; set; }
        public int? FacultyId { get; set; }
        public virtual Faculty Faculty { get; set; }
    }
}
