using AstonEcole.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AstonEcole.Services
{
    public class CourseWithNbStudents
    {
        public Course Course { get; set; }
        public int NbStudents { get; set; }
    }
}
