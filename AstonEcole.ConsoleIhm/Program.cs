using AstonEcole.ApiClient;
using AstonEcole.DTO;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace AstonEcole.ConsoleIhm
{
    class Program
    {
        static void Main(string[] args)
        {
            var svc = new AstonApiClient();
            //Student myriam = svc.GetStudent(3);
            //myriam.FirstName = "Philippe"; // { François }
            //myriam.FirstName = "Marswell2"; // { Mario }
            //myriam.FirstName = "Joris"; // { Myriam }
            //svc.UpdateStudent(myriam);
            //myriam = svc.GetStudent(3);
            //Console.WriteLine(myriam.FirstName);
            //Console.ReadLine();

            //List<CourseWithNbStudents> l = svc.GetCourseNbEleves();
            //l.ForEach(c => Console.WriteLine(c.Course+" "+c.NbStudents));
            //Console.Read();
        }
    }
}
