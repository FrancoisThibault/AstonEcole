using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AstonEcole.DTO
{
    public class Teacher
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Course> Courses { get; set; }
    }
}