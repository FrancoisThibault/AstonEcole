using Microsoft.VisualStudio.TestTools.UnitTesting;
using AstonEcole.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Text;
using System.Threading.Tasks;

namespace AstonEcole.DAL.Tests
{
    [TestClass()]
    public class AstonEcoleContextTests
    {
        [TestMethod()]
        public void AstonEcoleContextTest()
        {
            AstonEcoleContext ctx = new AstonEcoleContext();
            var x = ctx.Students.Select(s => new { Student = s, NbCours = s.Courses.Count() });
           // Assert.Fail();
        }
    }
}