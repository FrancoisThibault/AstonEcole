﻿using AstonEcole.ApiClient;
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
            var svc = new AstonEcoleApiClient();
            Student myriam = svc.GetStudent(1);
            myriam.FirstName = "Myriam";
            svc.UpdateStudent(myriam);
            myriam = svc.GetStudent(1);
            Console.WriteLine(myriam.FirstName);
            Console.ReadLine();
        }
    }
}
