using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using DAL.UOW;

namespace DAL
{
    class Program
    {
        static void Main(string[] args)
        {
            //CRUD
            //Create
            using (UnitOfWork uow = new UnitOfWork())
            {
                Teacher t1 = new Teacher
                {
                    Firstname = "Kateryna",
                    Lastname = "Ivankiv",
                    Position = "docent"
                };

                Student s1 = new Student
                {
                    Firstname = "Andrii",
                    Lastname = "Arkhipov",
                    GroupName = "PMP-42",
                    IdTeacherNavigation = t1
                };
                Student s2 = new Student
                {
                    Firstname = "Andrii",
                    Lastname = "Mudryk",
                    GroupName = "PMP-42",
                    IdTeacher = 3
                };

                uow.TeacherRepository.Insert(t1);
                uow.StudentRepository.Insert(s1);
                uow.StudentRepository.Insert(s2);
                uow.Save();
            }

            //Read
            using (UnitOfWork uow = new UnitOfWork())
            {
                var students = uow.StudentRepository.Get(s => s.Firstname == "Andrii");
                
                Console.WriteLine("Students with name Andrii:");
                foreach (var s in students)
                {
                    Console.WriteLine($"{s.Id} {s.Firstname} {s.Lastname}");
                }

                Console.WriteLine("\nStudents of particular teacher:");

                var teacher = uow.TeacherRepository.Get(t => t.Lastname == "Shcherbatyy", null, "Student").FirstOrDefault();

                
                foreach (var s in teacher.Student)
                {
                    Console.WriteLine($"{s.Firstname} {s.Lastname} {s.GroupName}");
                }

                
            }

            //Delete
            using (UnitOfWork uow = new UnitOfWork())
            {
                Student student = uow.StudentRepository.Get(s => s.Firstname == "Andrii").FirstOrDefault();
                uow.StudentRepository.Delete(student);
                uow.Save();
            }

            Console.Read();
        }
    }
}
