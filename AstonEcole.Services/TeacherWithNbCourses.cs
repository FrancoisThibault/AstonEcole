using AstonEcole.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AstonEcole.Services
{
    public class TeacherWithNbCourses
    {
        public Teacher Teacher { get; set; }
        public int NbCourses { get; set; }
    }
}
