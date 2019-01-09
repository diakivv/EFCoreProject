using System;
using System.Collections.Generic;
using System.Text;
using DAL.Repository;

namespace DAL.UOW
{
    interface IUnitOfWork
    {
        GenericRepository<Student> StudentRepository { get; }
        GenericRepository<Teacher> TeacherRepository { get; }
    }
}
