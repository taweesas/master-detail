using System.Diagnostics;
using TestMasterDetail.Models;

namespace TestMasterDetail.Data
{
    public class DbInitializer
    {
        public static void Initialize(ApplicationDbContext context)
        {
            // Look for any students.
            if (context.School.Any())
            {
                return;   // DB has been seeded
            }

            var school = new School[]
            {
                new School{Name="School 01"},
                new School{Name="School 02"}
            };

            context.School.AddRange(school);
            context.SaveChanges();

            var student = new Student[]
            {
                new Student{SchoolId=1,Name="Student 01"},
                new Student{SchoolId=2,Name="Student 02"},
                new Student{SchoolId=2,Name="Student 03"}
            };

            context.Student.AddRange(student);
            context.SaveChanges();

            var pet = new Pet[]
            {
                new Pet{StudentId=1, Name="Pet 01"},
                new Pet{StudentId=1, Name="Pet 02"},
                new Pet{StudentId=2, Name="Pet 03"},
                new Pet{StudentId=2, Name="Pet 04"},
                new Pet{StudentId=3, Name="Pet 05"},
                new Pet{StudentId=3, Name="Pet 06"}
            };

            context.Pet.AddRange(pet);
            context.SaveChanges();
        }
    }
}
