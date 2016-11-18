﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AstonEcole.DTO
{
    public class Student
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public ICollection<Course> Courses { get; set; }
    }

    public class StudentNbCours
    {
        public Student theStudent { get; set; }
        public int NbCours { get; set; }
    }


}