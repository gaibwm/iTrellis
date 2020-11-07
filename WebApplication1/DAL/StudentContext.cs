using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using WebApplication1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace WebApplication1.DAL
{
    public class StudentContext : DbContext
    {

        public StudentContext() : base("StudentContext")
        {
        }

        public DbSet<Student> Students { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }

    public class StudentInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<StudentContext>
    {
        protected override void Seed(StudentContext context)
        {
            var students = new List<Student>
            {
            new Student{FirstName="Lom",LastName="Phouthavongxay",Email="gaibwm@hotmail.com", StudentID="1", Address = "15468 se B st Clackamas OR 97015"},
            new Student{FirstName="John",LastName="Dole",Email="jDole@hotmail.com", StudentID="2", Address="1234 Main st Seattle WA 98660"},
            new Student{FirstName="Mark",LastName="J",Email="mj@hotmail.com", StudentID="3", Address="4578 45st Tacoma WA 98654"},
            new Student{FirstName="Chris",LastName="Standing", Email="cstanding@hotmail.com", StudentID="4", Address="4545 Sunny ave #233 Portland OR 97010"},
            new Student{FirstName="Mailman",LastName="Lin", Email="mlin@hotmail.com", StudentID="5", Address= "5756 Forster ave Salem OR 97066"},
            new Student{FirstName="Peggy",LastName="Box",Email="pbox@hotmail.com", StudentID="6", Address="5200 SE Salmon st Worcester MA 09776"},
            new Student{FirstName="Laura",LastName="Sam",Email="lsam@hotmail.com", StudentID="7", Address="34324 NE 90 st Portland ME 00987"},
            new Student{FirstName="Nino",LastName="Smark",Email="nsmark@hotmail.com", StudentID="8", Address="32424 Nine ave Tempe AZ 98663"}
            };

            students.ForEach(s => context.Students.Add(s));
            context.SaveChanges();
        }
    }
}
