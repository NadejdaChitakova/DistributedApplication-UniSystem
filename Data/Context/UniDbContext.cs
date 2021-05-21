using Data.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Context
{
    public class UniDbContext : DbContext
    {
       public DbSet<Student> Students { get; set; }
       public DbSet<Faculty> Faculties { get; set; }
       
       public DbSet<Speciality> Specialties { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Faculty>()
            //    .HasMany<Specialty>(g => g.Specialties)
            //    .WithRequired(s => s.Faculty)
            //    .HasForeignKey(s => s.FacultyId)
            //    .WillCascadeOnDelete();
            //modelBuilder.Entity<Specialty>()
            //    .HasMany<Student>(g => g.Students)
            //    .WithRequired(s => s.CurrentSpeciality)
            //    .HasForeignKey(s => s.SpecialityId)
            //    .WillCascadeOnDelete();

        }

    }
}
