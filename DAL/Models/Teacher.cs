using System;
using System.Collections.Generic;

namespace DAL
{
    public partial class Teacher
    {
        public Teacher()
        {
            Student = new HashSet<Student>();
        }

        public int Id { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Position { get; set; }

        public virtual ICollection<Student> Student { get; set; }
    }
}
