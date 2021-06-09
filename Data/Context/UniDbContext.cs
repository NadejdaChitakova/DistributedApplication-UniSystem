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
            modelBuilder.Entity<Faculty>()
                        .HasMany<Speciality>(f => f.Specialities)
                        .WithRequired(s => s.Faculty)
                        .WillCascadeOnDelete();
            modelBuilder.Entity<Speciality>()
                        .HasMany<Student>(s => s.Students)
                        .WithRequired(st => st.CurrentSpeciality)
                        .WillCascadeOnDelete();

        }

    }
}
