using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AstonEcole.DTO
{
    public class Course
    {
        public int Id { get; set; }
        public string Subject { get; set; }
        public ICollection<Student> Students { get; set; }
        public Teacher Teacher { get; set; }
    }
}