using System;
using System.Collections.Generic;

namespace DAL
{
    public partial class Student
    {
        public int Id { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string GroupName { get; set; }
        public int? IdTeacher { get; set; }

        public virtual Teacher IdTeacherNavigation { get; set; }
    }
}
