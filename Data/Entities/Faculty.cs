using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities
{
    public class Faculty
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
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
        public virtual ICollection<Speciality> Specialities { get; set; }
    }
}
