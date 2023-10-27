using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using System.Collections.Generic;
using System.Reflection.Emit;
using TestMasterDetail.Models;

namespace TestMasterDetail.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<School> School { get; set; }
        public DbSet<Student> Student { get; set; }
        public DbSet<Pet> Pet { get; set; }

        public ApplicationDbContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<School>().HasData(
                new School { Id = 1, Name = "School 01" },
                new School { Id = 2, Name = "School 02" });

            builder.Entity<Student>().HasData(
                new Student { Id = 1, SchoolId = 1, Name = "Student 01" },
                new Student { Id = 2, SchoolId = 2, Name = "Student 02" },
                new Student { Id = 3, SchoolId = 2, Name = "Student 03" });

            builder.Entity<Pet>().HasData(
                new Pet { Id = 1, StudentId = 1, Name = "Pet 01" },
                new Pet { Id = 2, StudentId = 1, Name = "Pet 02" },
                new Pet { Id = 3, StudentId = 2, Name = "Pet 03" },
                new Pet { Id = 4, StudentId = 2, Name = "Pet 04" },
                new Pet { Id = 5, StudentId = 3, Name = "Pet 05" },
                new Pet { Id = 6, StudentId = 3, Name = "Pet 06" });
        }
    }
}
