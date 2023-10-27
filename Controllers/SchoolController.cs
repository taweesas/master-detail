using DataTablesParser;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography.X509Certificates;
using System.Text.Json;
using TestMasterDetail.Data;
using TestMasterDetail.Models;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace TestMasterDetail.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class SchoolController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public SchoolController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public IActionResult GetListSchoolData()
        {
            var school = _context.School.Select(c => new DatatableResult
            {
                SchoolId = c.Id,
                SchoolName = c.Name,
                StudentId = c.Student.FirstOrDefault().Id,
                StudentName = c.Student.FirstOrDefault().Name,
                PetId = c.Student.FirstOrDefault().Pet.FirstOrDefault().Id,
                PetName = c.Student.FirstOrDefault().Pet.FirstOrDefault().Name
            });

            var parser = new Parser<DatatableResult>(Request.Form, school);

            return Ok(JsonSerializer.Serialize(parser.Parse()));
        }

        [HttpGet]
        public IActionResult GetListStudentData(int id)
        {
            var student = _context.Student.Select(c => new DatatableResult
            {
                SchoolId = c.School.Id,
                SchoolName = c.School.Name,
                StudentId = c.Id,
                StudentName = c.Name,
                PetId = c.Pet.FirstOrDefault().Id,
                PetName = c.Pet.FirstOrDefault().Name
            }).Where(c => c.SchoolId == id);

            var jsonOptions = new JsonSerializerOptions
            {
                PropertyNamingPolicy = null
            };

            var json = JsonSerializer.Serialize(student, jsonOptions);

            return new ContentResult
            {
                Content = json,
                ContentType = "application/json",
                StatusCode = 200
            };
        }

        public IActionResult GetListPetData(int id)
        {
            var pet = _context.Pet.Select(c => new DatatableResult
            {
                SchoolId = c.Student.School.Id,
                SchoolName = c.Student.School.Name,
                StudentId = c.Student.Id,
                StudentName = c.Student.Name,
                PetId = c.Id,
                PetName = c.Name
            }).Where(c => c.StudentId == id);

            var jsonOptions = new JsonSerializerOptions
            {
                PropertyNamingPolicy = null
            };

            var json = JsonSerializer.Serialize(pet, jsonOptions);

            return new ContentResult
            {
                Content = json,
                ContentType = "application/json",
                StatusCode = 200
            };
        }

        public class DatatableResult
        {
            public int SchoolId { get; set; }
            public string SchoolName { get; set; }
            public int StudentId { get; set; }
            public string StudentName { get; set; }
            public int PetId { get; set; }
            public string PetName { get; set; }
        }
    }
}
