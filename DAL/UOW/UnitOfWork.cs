using System;
using System.Collections.Generic;
using System.Text;
using DAL.Repository;

namespace DAL.UOW
{
    class UnitOfWork : IUnitOfWork, IDisposable
    {
        EducationContext context = new EducationContext();
        GenericRepository<Student> studentRepository;
        GenericRepository<Teacher> teacherRepository;

        public GenericRepository<Student> StudentRepository
        {
            get
            {
                if (this.studentRepository == null)
                {
                    this.studentRepository = new GenericRepository<Student>(context);
                }
                
                return this.studentRepository;
            }
        }

        public GenericRepository<Teacher> TeacherRepository
        {
            get
            {
                if (this.teacherRepository == null)
                {
                    this.teacherRepository = new GenericRepository<Teacher>(context);
                }

                return this.teacherRepository;
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

                this.disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
