using AstonEcole.DTO;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AstonEcole.DAL
{
    public class AstonEcoleContext : DbContext
    {
        public AstonEcoleContext() : base("AstonDB")
        {
        }

        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Student> Students { get; set; }
    }
}
