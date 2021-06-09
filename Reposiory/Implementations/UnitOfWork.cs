using Data.Context;
using Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reposiory.Implementations
{

    public class UnitOfWork : IDisposable
    {
        private UniDbContext context = new UniDbContext();
        private GenericRepository<Student> studentRepository;
        private GenericRepository<Speciality> specialityRepository;
        private GenericRepository<Faculty> facultyRepository;

        public GenericRepository<Student> StudentRepository
        {
            get
            {

                if (this.studentRepository == null)
                {
                    this.studentRepository = new GenericRepository<Student>(context);
                }
                return studentRepository;
            }
        }

        public GenericRepository<Speciality> SpecialityRepository
        {
            get
            {

                if (this.specialityRepository == null)
                {
                    this.specialityRepository = new GenericRepository<Speciality>(context);
                }
                return specialityRepository;
            }
        }
        public GenericRepository<Faculty> FacultyRepository
        {
            get
            {

                if (this.facultyRepository == null)
                {
                    this.facultyRepository = new GenericRepository<Faculty>(context);
                }
                return facultyRepository;
            }
        }

        public void Save()
        {
            context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
