using AstonEcole.oDataClient.ServiceReference1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AstonEcole.oDataClient
{
    class Program
    {
        static void Main(string[] args)
        {
            Container cnx = new Container(new Uri("http://localhost:54804/odata"));
            var x = from s in cnx.Students
                    where s.FirstName.Length > 5
                    select s;
            x.ToList().ForEach(s => Console.WriteLine(s.FirstName));

            Student student = cnx.Students.Where(s => s.Id == 1).Single();
            student.FirstName = "MYRIAM";
            cnx.UpdateObject(student);
            cnx.SaveChanges(System.Data.Services.Client.SaveChangesOptions.PatchOnUpdate);

            x.ToList().ForEach(s => Console.WriteLine(s.FirstName));


            Console.ReadLine();
        }
    }
}
